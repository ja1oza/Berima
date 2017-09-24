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

        public async Task<IActionResult> History()
        {
            var user = await _userManager.GetUserAsync(User);
            var purchases = await _context.Purchases
                .Where(dao => dao.User == user)
                .OrderByDescending(dao => dao.DateTime)
                .Take(5)
                .Include(dao => dao.Commodity)
                .Select(dao => dao.Read())
                .ToListAsync();
            return View(purchases);
        }
    }
}