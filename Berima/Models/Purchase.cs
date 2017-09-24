using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models
{
    public class Purchase
    {
        public readonly Commodity _commodity;

        public Purchase(Commodity commodity, int price, DateTime dateTime)
        {
            _commodity = commodity;
            Price = price;
            DateTime = dateTime;
        }

        [DisplayName("商品名")]
        public string CommodityName => _commodity.Name;
        [DisplayName("値段")]
        public int Price { get; set; }
        [DisplayName("購入日時")]
        public DateTime DateTime { get; set; }
    }
}
