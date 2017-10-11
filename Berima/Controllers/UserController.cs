using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Berima.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Berima.Models;
using Microsoft.EntityFrameworkCore;
using Berima.Models.UserViewModels;

namespace Berima.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> History([FromQuery] int page = 0)
        {
            var itemsPerPage = 20;

            var user = await _userManager.GetUserAsync(User);
            var purchasesCount = await _context.Purchases
                .CountAsync(dao => dao.User == user);
            var purchases = await _context.Purchases
                .Where(dao => dao.User == user)
                .OrderByDescending(dao => dao.DateTime)
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .Include(dao => dao.Commodity)
                .Select(dao => dao.Read())
                .ToListAsync();
            return View(new HistoryViewModel
            {
                Purchases = purchases,
                CurrentPage = page,
                HasPrevious = page > 0,
                HasNext = purchasesCount > (page + 1) * itemsPerPage,
                ItemsPerPage = itemsPerPage
            });
        }
    }
}