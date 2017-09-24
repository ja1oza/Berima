using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models.CatalogViewModels
{
    public class CatalogViewModel
    {
        public IEnumerable<Commodity> Commodities { get; set; }

        [Required]
        public int BuyingId { get; set; }
    }
}
