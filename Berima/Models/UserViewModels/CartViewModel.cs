using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models.UserViewModels
{
    public class CartViewModel
    {
        public IEnumerable<CartRecord> Records { get; set; }
    }
}
