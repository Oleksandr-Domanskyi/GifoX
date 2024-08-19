using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Infrastructure.Repositories;

namespace Coupons.Service.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        ICouponeRepository Repository { get; }
    }
}