using System;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.Replication;
using Product.Application.CQRS.Queries.ProductGetAll;

namespace Product.Application.Extensions;

public static class ProductApplicationExtensions
{
    public static void AddProductApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ProductGetAllQueryHandler).Assembly));
    }

}
