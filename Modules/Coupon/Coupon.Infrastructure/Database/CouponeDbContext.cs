using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Database;

namespace Coupons.Service.Infrastructure.Data
{
    public class CouponeDbContext : ModuleDbContext
    {
        protected override string Schema => "Coupone";
        public CouponeDbContext(DbContextOptions<CouponeDbContext> options) : base(options)
        {

        }
        public DbSet<CouponModel> Coupon { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}