using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models
{
    public class CommodityIconDAO
    {
        public int Id { get; set; }
        [Required]
        public string Data { get; set; }

        public CommodityIcon Read()
        {
            return new CommodityIcon(Data);
        }
    }
}
