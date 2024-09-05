using System;
using FluentResults;
using Product.Core.Dto;

namespace Product.Infrastructure.Services.IServices.IProductSharedServices;

public interface IProductCouponIntegrationService
{
    Task<Result<ProductDto>> ApplyCouponeToProduct(Guid id, string CouponeCode);
}
