using System;

namespace Shared.Infrastructure.Database.IConfiguration;

public interface IMigrationPathConfiguration
{
    public string MigrationsAssemblyName { get; }
}
