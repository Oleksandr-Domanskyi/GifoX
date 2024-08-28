using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Coupons.Service.Infrastructure.Data.Seed;
using Coupons.Service.Infrastructure.UnitOfWork;
using Coupons.Service.Infrastructure.Repositories;
using Coupons.Service.Infrastructure.Services.RepositoryServices;

namespace Coupons.Service.Infrastructure.Extentions
{
    public static class CouponeInfrastructureExtention
    {
        public static void AddCouponeInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CouponeDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ConnectionStrings")));

            services.AddScoped<CouponeSeeder>();

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<ICouponeRepository, CouponeRepository>();
            services.AddScoped<ICouponeRepositoryService, CouponRepositoryService>();
        }
        public static async Task AddCouponeSeeder(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<CouponeSeeder>();
            await seeder.Seed();
        }


    }
}