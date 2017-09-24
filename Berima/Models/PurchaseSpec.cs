using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berima.Models
{
    public class PurchaseSpec
    {
        public PurchaseSpec(ApplicationUser user, Commodity commodity)
        {
            User = user;
            Commodity = commodity;
        }

        public ApplicationUser User { get; }
        public Commodity Commodity { get; }
    }
}
