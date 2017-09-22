using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Berima.Models;
using Berima.Data;
using Microsoft.EntityFrameworkCore;

namespace Berima.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var daoList = await _context.Commodities
                .Include(dao => dao.Icon)
                .ToListAsync();
            return base.View(daoList.Select(dao => dao.Read()));
        }
    }
}