using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Berima.Models;

namespace Berima.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            var commodities = new List<Commodity>();
            commodities.Add(new Commodity("商品1", 100, "images/banner1.svg"));
            commodities.Add(new Commodity("商品2", 80, "images/banner2.svg"));
            commodities.Add(new Commodity("商品3", 1000, "images/banner1.svg"));
            commodities.Add(new Commodity("商品4", 256, "images/banner3.svg"));
            commodities.Add(new Commodity("商品5", 812, "images/banner4.svg"));
            ViewData["commodities"] = commodities;
            return View();
        }
    }
}