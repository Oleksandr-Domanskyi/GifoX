using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Infrastructure.Repositories;
using Coupons.Service.Infrastructure.Data;

namespace Coupons.Service.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private readonly CouponeDbContext _dbContext;
        private readonly ICouponeRepository _couponeRepository;

        public UnitOfWork(CouponeDbContext dbContext, ICouponeRepository couponeRepository)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _couponeRepository = couponeRepository;
        }

        public ICouponeRepository Repository => _couponeRepository;

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext?.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}