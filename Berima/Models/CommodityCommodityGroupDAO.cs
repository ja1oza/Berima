using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models
{
    public class CommodityCommodityGroupDAO
    {
        public int CommodityDAOId { get; set; }
        public CommodityDAO CommodityDAO { get; set; }

        public int CommodityGroupDAOId { get; set; }
        public CommodityGroupDAO CommodityGroupDAO { get; set; }
    }
}
