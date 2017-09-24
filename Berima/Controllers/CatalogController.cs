using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Berima.Models;
using Berima.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Berima.Models.CatalogViewModels;

namespace Berima.Controllers
{
    [Authorize]
    public class CatalogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var daoList = await _context.Commodities
                .Include(dao => dao.Icon)
                .ToListAsync();
            return View(new CatalogViewModel
            {
                Commodities = daoList.Select(dao => dao.Read())
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buy(CatalogViewModel model)
        {
            var commodity = await _context.Commodities
                .FirstAsync(dao => dao.Id == model.BuyingId);
            if (commodity == null)
            {
                return NotFound(model.BuyingId);
            }
            return Ok();
        }
    }
}