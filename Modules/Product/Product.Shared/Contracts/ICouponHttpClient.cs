using Coupons.Service.Core.Dto;

namespace Product.Shared.Contracts;

public interface ICouponHttpClient
{
    Task<CouponDto> GetSharedCouponeByCode(string CouponeCode);
}
