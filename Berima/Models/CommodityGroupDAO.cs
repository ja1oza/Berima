using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models
{
    public class CommodityGroupDAO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<CommodityCommodityGroupDAO> Commodities { get; set; }

        public CommodityGroup Read()
        {
            return new CommodityGroup(Id, Name,
                Commodities.Select(ccg => ccg.CommodityDAO.Read())
                .ToList());
        }
    }
}
