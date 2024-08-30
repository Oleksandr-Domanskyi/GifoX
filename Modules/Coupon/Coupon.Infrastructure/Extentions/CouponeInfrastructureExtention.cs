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
using Shared.Infrastructure.Database;
using Shared.Infrastructure.Extensions;

namespace Coupons.Service.Infrastructure.Extentions
{
    public static class CouponeInfrastructureExtention
    {
        public static void AddCouponeInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseContext<CouponeDbContext>(configuration);

            services.AddScoped<IDatabaseSeederConfiguration, CouponeSeeder>();

            services.AddScoped<ICouponeRepository, CouponeRepository>();
            services.AddScoped<ICouponeRepositoryService, CouponRepositoryService>();
        }


    }
}