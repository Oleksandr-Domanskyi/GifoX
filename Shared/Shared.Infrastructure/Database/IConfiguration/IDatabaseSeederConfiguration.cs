using System;

namespace Shared.Infrastructure.Database;

public interface IDatabaseSeederConfiguration
{
    public Task Seed();
}
