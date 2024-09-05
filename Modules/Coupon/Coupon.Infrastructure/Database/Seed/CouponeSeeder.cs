using Coupons.Service.Core.Domain;
using Shared.Infrastructure.Database;
using Shared.Shared.Core.Enum.CouponEnum;

namespace Coupons.Service.Infrastructure.Data.Seed
{
    public class CouponeSeeder : IDatabaseSeederConfiguration
    {
        private readonly CouponeDbContext _dbContext;

        public CouponeSeeder(CouponeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Coupon.Any())
                {
                    var seed = new List<CouponModel>()
                    {
                        new CouponModel(){
                            Id = Guid.NewGuid(),
                            CouponCode = "XD21ZHS",
                            MinAmount = 40,
                            DiscountAmount = 20,
                            DiscountType = CouponDiscountTypes.Percentage.ToString(),
                            CanBeUsed = true,
                            UsableAmount = 1
                        },
                         new CouponModel(){
                            Id = Guid.NewGuid(),
                            CouponCode = "FoXiDerD",
                            MinAmount = 10,
                            DiscountAmount = 5,
                            DiscountType = CouponDiscountTypes.FixedAmount.ToString(),
                            CanBeUsed = true,
                            UsableAmount = 2
                        },
                         new CouponModel(){
                            Id = Guid.NewGuid(),
                            CouponCode = "3Fe2ZoZDX",
                            MinAmount = 120,
                            DiscountAmount = 60,
                            DiscountType = CouponDiscountTypes.Percentage.ToString(),
                            CanBeUsed = true,
                            UsableAmount = 3
                        },
                         new CouponModel(){
                            Id = Guid.NewGuid(),
                            CouponCode = "X23S14SDZc",
                            MinAmount = 15,
                            DiscountAmount = 7.5,
                            DiscountType = CouponDiscountTypes.FixedAmount.ToString(),
                            CanBeUsed = true,
                            UsableAmount = 4
                        },
                    };
                    _dbContext.Coupon.AddRange(seed);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}