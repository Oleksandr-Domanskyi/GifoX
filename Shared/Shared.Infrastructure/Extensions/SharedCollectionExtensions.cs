using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.Database;

namespace Shared.Infrastructure.Extensions;

public static class SharedCollectionExtensions
{
    public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        
    }
    public static void AddDatabaseContext<T>(this IServiceCollection services, IConfiguration configuration)
    where T : DbContext
    {
        services.AddDbContext<T>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("ConnectionStrings"),
                                e => e.MigrationsAssembly(typeof(T).Assembly.FullName));
        });
    }

}
