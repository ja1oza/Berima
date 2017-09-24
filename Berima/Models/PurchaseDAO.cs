using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models
{
    public class PurchaseDAO
    {
        public static PurchaseDAO Create(PurchaseSpec spec)
        {
            return new PurchaseDAO
            {
                User = spec.User,
                Commodity = CommodityDAO.From(spec.Commodity),
                Price = spec.Commodity.Price
            };
        }

        public int Id { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        [Required]
        public CommodityDAO Commodity { get; set; }
        [Required]
        public int Price { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateTime { get; set; }

        public Purchase Read()
        {
            return new Purchase(Commodity.Read(), Price, DateTime);
        }
    }
}
