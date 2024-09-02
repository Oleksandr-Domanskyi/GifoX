using System;
using Product.Shared.Dtos;
using Product.Shared.Responses;

namespace Product.Shared.Contracts;

public interface ICouponHttpClient
{
    Task<CouponeResponse<CouponeDtoResponse>> ApplyCouponeAsync(string CouponeCode);
}
