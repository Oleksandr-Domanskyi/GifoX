using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Shared.ApiClients;
using Product.Shared.Contracts;

namespace Product.Shared.Extensions
{
    public static class ProductSharedExtensions
    {
        public static void AddProductShared(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ICouponHttpClient, CouponHttpClient>(client =>
            {
                var baseUrl = configuration["CouponModule:BaseUrl"];
                client.BaseAddress = new Uri(baseUrl!);
            });
        }
    }
}
