using System;

namespace Shared.Infrastructure.Database;

public interface IDbContextSeederConfiguration
{
    public Task Seed();
}
