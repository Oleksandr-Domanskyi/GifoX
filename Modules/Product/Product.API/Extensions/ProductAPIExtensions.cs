using System;
using Product.Infrastructure.Extensions;
using Product.Shared.Extensions;
using Product.Application.Extensions;

namespace Product.API.Extensions;

public static class ProductAPIExtensions
{
    public static void AddProductModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddProductApplication();
        services.AddProductInfrastructure(configuration);
        services.AddProductShared(configuration);
    }

}
