using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Domain;

namespace Coupons.Service.Infrastructure.Repositories
{
    public interface ICouponeRepository
    {
        Task<IEnumerable<CouponModel>> GetAllAsync();
        Task<CouponModel> GetByIdAsync(Guid Id);
        Task<CouponModel> GetByCodeAsync(string code);
        Task<CouponModel> AddCouponeAsync(CouponModel model);
        CouponModel UpdateCoupone(CouponModel model);
        Task DeleteCouponeAsync(Guid Id);
    }
}