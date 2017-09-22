using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models
{
    public class Commodity
    {
        private readonly int _price;
        private readonly CommodityIcon _icon;

        public Commodity(string name, int price, CommodityIcon icon)
        {
            Name = name;
            _price = price;
            _icon = icon;
        }

        public string Name { get; }
        public string Price => _price + "円";
        public string Icon => _icon.StringValue;
    }
}
