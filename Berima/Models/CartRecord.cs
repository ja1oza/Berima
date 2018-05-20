using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models
{
    public class CartRecord
    {
        private Commodity _commodity;

        public CartRecord(string userId, Commodity commodity,
            int commodityCount)
        {
            UserId = userId;
            _commodity = commodity;
            CommodityCount = commodityCount;
        }

        public string UserId { get; set; }
        [DisplayName("商品名")]
        public string CommodityName => _commodity.Name;
        [DisplayName("個数")]
        public int CommodityCount { get; set; }
        [DisplayName("値段")]
        public int Price => _commodity.Price * CommodityCount;
    }
}
