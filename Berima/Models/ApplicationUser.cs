using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Berima.Data;

namespace Berima.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int Money { get; set; }

        public bool CanBuy(Commodity commodity)
        {
            return Money >= commodity.Price;
        }

        public void Buy(Commodity commodity, ApplicationDbContext context)
        {
            var purchase = new Purchase(this, commodity);
            context.Purchases.Add(PurchaseDAO.Create(purchase));
            Money -= commodity.Price;
        }
    }
}
