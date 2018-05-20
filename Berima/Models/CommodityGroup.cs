using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models
{
    public class CommodityGroup
    {
        public CommodityGroup(int id, string name, List<Commodity> commodities)
        {
            Id = id;
            Name = name;
            Commodities = commodities;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Commodity> Commodities { get; set; }
    }
}
