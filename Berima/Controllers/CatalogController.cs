﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Berima.Models;
using Berima.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Berima.Models.CatalogViewModels;
using Microsoft.AspNetCore.Identity;

namespace Berima.Controllers
{
    [Authorize]
    public class CatalogController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CatalogController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var daoList = await _context.Groups
                .Include(dao => dao.Commodities)
                .ThenInclude(ccg => ccg.CommodityDAO)
                .ThenInclude(c => c.Icon)
                .ToListAsync();
            var freeCommodities = await _context.Commodities
                .Where(c => c.Groups.Count() == 0)
                .Include(c => c.Icon)
                .ToListAsync();
            return View(new CatalogViewModel
            {
                Groups = daoList.Select(dao => dao.Read()),
                FreeCommodities = freeCommodities.Select(dao => dao.Read())
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buy(CatalogViewModel model)
        {
            var commodityDAO = await _context.Commodities
                .SingleOrDefaultAsync(c => c.Id == model.BuyingId);
            if (commodityDAO == null)
            {
                return NotFound(model.BuyingId);
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var commodity = commodityDAO.Read();
            using (var transaction = _context.Database.BeginTransaction())
            {
                if (!user.CanBuy(commodity))
                {
                    return BadRequest("お金が足りません");
                }

                user.Buy(commodity, _context);
                await _context.SaveChangesAsync();
                transaction.Commit();
            }
            return Ok();
        }
    }
}