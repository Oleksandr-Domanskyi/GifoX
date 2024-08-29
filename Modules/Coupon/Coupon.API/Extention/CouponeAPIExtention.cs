using System;
using Coupons.Service.Application.Extentions;
using Coupons.Service.Infrastructure.Data;
using Coupons.Service.Infrastructure.Extentions;
using Shared.Infrastructure.Extensions;

namespace Coupons.API.Extention;

public static class CouponeAPIExtention
{
    public static void AddCouponeModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCouponeApplication();
        services.AddCouponeInfrastructure(configuration);

        services.AddDatabaseContext<CouponeDbContext>(configuration);


    }
}
