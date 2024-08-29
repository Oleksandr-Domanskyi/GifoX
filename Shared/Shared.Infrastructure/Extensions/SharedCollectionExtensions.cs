using System;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Infrastructure.Database;
using Shared.Infrastructure.Database.IConfiguration;

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
            var path = typeof(T).Assembly.FullName;
        });
    }

    public static async void SeedAllDbContext(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var seeders = services.GetServices<IDatabaseSeederConfiguration>();
            foreach (var seeder in seeders)
            {
                await seeder.Seed();
            }
        }
    }

}
