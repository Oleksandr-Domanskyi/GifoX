using System;

namespace Coupon.Shared.Contracts;

public interface IProductHttpClient
{
    Task<double> GetProductPrice(Guid id);
}
