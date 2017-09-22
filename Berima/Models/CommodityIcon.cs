using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models
{
    public class CommodityIcon
    {
        private readonly string _data;

        public CommodityIcon(string data)
        {
            _data = data;
        }

        public string StringValue => _data;
    }
}
