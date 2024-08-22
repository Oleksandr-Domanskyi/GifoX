using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Coupons.Service.Core.Domain;
using Coupons.Service.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Coupons.Service.Infrastructure.Repositories
{
    public class CouponeRepository : ICouponeRepository
    {
        private readonly CouponeDbContext _dbContext;
        public CouponeRepository(CouponeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CouponModel>> GetAllAsync() => await _dbContext.Coupon.ToListAsync();
        public async Task<CouponModel> GetByIdAsync(Guid Id) => await _dbContext.Coupon.FirstAsync(x => x.Id == Id);
        public async Task<CouponModel> GetByCodeAsync(string code)
        {
            var entity = await _dbContext.Coupon.Where(x => x.CouponCode == code).FirstOrDefaultAsync();
            return entity == null || entity.CanBeUsed != true
                ? throw new Exception
                ($"Coupone with code: {code} not found or Coupon has exhausted all its usage opportunities!!!")
                : entity;
        }
        public async Task<CouponModel> AddCouponeAsync(CouponModel model)
        {
            await _dbContext.Coupon.AddAsync(model);
            return model;
        }
        public CouponModel UpdateCoupone(CouponModel model)
        {
            _dbContext.Coupon.Update(model);
            return model;
        }
        public async Task DeleteCouponeAsync(Guid Id)
        {
            var model = await _dbContext.Coupon.FirstAsync(src => src.Id == Id);
            _dbContext.Coupon.Remove(model);
        }

    }
}