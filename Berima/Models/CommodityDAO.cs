using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models
{
    public class CommodityDAO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Price { get; set; }
        public CommodityIconDAO Icon { get; set; }

        public Commodity Read()
        {
            return new Commodity(Id, Name, Price, Icon?.Read());
        }
    }
}
