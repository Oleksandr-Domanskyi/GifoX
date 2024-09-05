using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Infrastructure.Database.DbContext;
using Product.Infrastructure.Database.Seed;
using Product.Infrastructure.Repositories;
using Product.Infrastructure.Repositories.IRepositories;
using Product.Infrastructure.Services.IServices;
using Product.Infrastructure.Services.IServices.IProductSharedServices;
using Product.Infrastructure.Services.IServices.IProductSharedServices.IHandler;
using Product.Infrastructure.Services.ProductRepositoryServices;
using Product.Infrastructure.Services.ProductSharedServices;
using Shared.Core.CouponShared.Handlers;
using Shared.Infrastructure.Database;
using Shared.Infrastructure.Extensions;

namespace Product.Infrastructure.Extensions;

public static class ProductInfrastructureExtentions
{
    public static void AddProductInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseContext<ProductDbContext>(configuration);

        services.AddScoped<IDatabaseSeederConfiguration, ProductSeeder>();

        services.AddScoped<IProductCouponIntegrationService, ProductCouponIntegrationService>();
        services.AddScoped<IProductRepositoryServices, ProductRepositoryServices>();
        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddHandlers();
    }
    public static void AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<IDiscountTypeHandler, DiscountTypeHandler>();
    }
}
