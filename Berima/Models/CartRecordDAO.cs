using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models
{
    public class CartRecordDAO
    {
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int CommodityId { get; set; }
        public CommodityDAO Commodity { get; set; }

        public int CommodityCount { get; set; }
    }
}
