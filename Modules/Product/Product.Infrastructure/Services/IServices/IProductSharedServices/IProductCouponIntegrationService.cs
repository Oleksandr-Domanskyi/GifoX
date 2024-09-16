using System;
using FluentResults;
using Product.Core.Dto;
using Shared.Core.ProductShared.Dto;

namespace Product.Infrastructure.Services.IServices.IProductSharedServices;

public interface IProductCouponIntegrationService
{
    Task<Result<ProductDto>> ApplyCouponeToProduct(Guid id, string CouponeCode);
}
