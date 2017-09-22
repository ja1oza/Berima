﻿using System;
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
            var commodities = new List<Commodity>
            {
                new Commodity("商品1", 100, new CommodityIcon("png", "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")),
                new Commodity("商品2", 80, new CommodityIcon("png", "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")),
                new Commodity("商品3", 1000, new CommodityIcon("png", "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")),
                new Commodity("商品4", 256, new CommodityIcon("png", "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")),
                new Commodity("商品5", 812, new CommodityIcon("png", "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"))
            };
            ViewData["commodities"] = commodities;
            return View();
        }
    }
}