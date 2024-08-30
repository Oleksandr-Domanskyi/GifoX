
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.RepositoriesManager;

namespace Shared.Shared.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork<TDbContext, TRepository> : IDisposable
    where TDbContext : DbContext
    where TRepository : IRepository
    {
        Task<int> SaveChangesAsync();
        TRepository Repository { get; }
    }
}