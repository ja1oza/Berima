using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models
{
    public class Commodity
    {
        private readonly int _price;

        public Commodity(string name, int price, string icon)
        {
            Name = name;
            _price = price;
            Icon = icon;
        }

        public string Name { get; }
        public string Price => _price + "円";
        public string Icon { get; }
    }
}
