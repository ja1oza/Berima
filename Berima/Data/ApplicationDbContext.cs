using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Berima.Models;

namespace Berima.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<PurchaseDAO>()
                .Property(p => p.DateTime)
                .HasDefaultValueSql("getdate()");

            builder.Entity<CommodityCommodityGroupDAO>()
                .HasKey(p => new { p.CommodityDAOId, p.CommodityGroupDAOId });

            builder.Entity<CommodityCommodityGroupDAO>()
                .HasOne(p => p.CommodityDAO)
                .WithMany(c => c.Groups)
                .HasForeignKey(p => p.CommodityDAOId);

            builder.Entity<CommodityCommodityGroupDAO>()
                .HasOne(p => p.CommodityGroupDAO)
                .WithMany(g => g.Commodities)
                .HasForeignKey(p => p.CommodityGroupDAOId);
        }

        public DbSet<CommodityDAO> Commodities { get; set; }
        public DbSet<CommodityIconDAO> CommodityIcons { get; set; }
        public DbSet<PurchaseDAO> Purchases { get; set; }
        public DbSet<CommodityGroupDAO> Groups { get; set; }
    }
}
