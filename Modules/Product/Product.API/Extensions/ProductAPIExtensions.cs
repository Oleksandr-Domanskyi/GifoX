using System;
using Product.Infrastructure.Extensions;

namespace Product.API.Extensions;

public static class ProductAPIExtensions
{
    public static void AddProductModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddProductInfrastructure(configuration);
    }

}
