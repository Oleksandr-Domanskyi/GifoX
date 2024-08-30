using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Domain;
using Shared.Infrastructure.RepositoriesManager;

namespace Coupons.Service.Infrastructure.Repositories
{
    public interface ICouponeRepository : IRepository
    {
        Task<IEnumerable<CouponModel>> GetAllAsync();
        Task<CouponModel> GetByIdAsync(Guid Id);
        Task<CouponModel> GetByCodeAsync(string code);
        Task<CouponModel> AddCouponeAsync(CouponModel model);
        CouponModel UpdateCoupone(CouponModel model);
        Task DeleteCouponeAsync(Guid Id);
    }
}