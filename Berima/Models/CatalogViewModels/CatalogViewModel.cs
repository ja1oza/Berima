using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models.CatalogViewModels
{
    public class CatalogViewModel
    {
        public IEnumerable<CommodityGroup> Groups { get; set; }
        public IEnumerable<Commodity> FreeCommodities { get; set; }

        [Required]
        public int BuyingId { get; set; }
    }
}
