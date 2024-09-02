using System;
using Product.Infrastructure.Extensions;
using Product.Shared.Extensions;

namespace Product.API.Extensions;

public static class ProductAPIExtensions
{
    public static void AddProductModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddProductInfrastructure(configuration);
        services.AddProductShared(configuration);
    }

}
