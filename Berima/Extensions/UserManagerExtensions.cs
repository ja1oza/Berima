using Berima.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Berima.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<int> GetUserMoneyAsync(this UserManager<ApplicationUser> manager, ClaimsPrincipal principal)
        {
            var user = await manager.GetUserAsync(principal);
            return user.Money;
        }
    }
}
