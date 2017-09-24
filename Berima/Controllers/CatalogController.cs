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
            var purchase = new Purchase(user, commodityDAO.Read());
            _context.Purchases.Add(PurchaseDAO.Create(purchase));
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}