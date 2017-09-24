using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models
{
    public class Commodity
    {
        private readonly CommodityIcon _icon;

        public Commodity(int id, string name, int price, CommodityIcon icon)
        {
            Id = id;
            Name = name;
            Price = price;
            _icon = icon;
        }

        public int Id { get; }
        public string Name { get; }
        public int Price { get; }

        public string PriceString => Price + "円";
        public string Icon => _icon?.StringValue;
    }
}
