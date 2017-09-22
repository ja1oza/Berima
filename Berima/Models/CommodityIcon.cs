using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models
{
    public class CommodityIcon
    {
        private readonly string _type;
        private readonly string _data;

        public CommodityIcon(string type, string data)
        {
            _type = type;
            _data = data;
        }

        public string StringValue => $"data:image/{_type};base64,{_data}";
    }
}
