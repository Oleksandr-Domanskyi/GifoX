using System;
using Coupons.Service.Core.Dto;
using FluentResults;
using Product.Core.Dto;
using Product.Infrastructure.Database.DbContext;
using Product.Infrastructure.Repositories.IRepositories;
using Product.Infrastructure.Services.IServices.IProductSharedServices;
using Product.Infrastructure.Services.IServices.IProductSharedServices.IHandler;
using Product.Product.Core.Domain;
using Product.Product.Infrastructure.CustomMapper;
using Product.Shared.Contracts;
using Shared.Core.ProductShared.Dto;
using Shared.Shared.Core.Enum.CouponEnum;
using Shared.Shared.Infrastructure.UnitOfWork;

namespace Product.Infrastructure.Services.ProductSharedServices;

public class ProductCouponIntegrationService : IProductCouponIntegrationService
{
    private readonly IUnitOfWork<ProductDbContext, IProductRepository> _unitOfWork;
    private readonly ICouponHttpClient _couponHttpClient;
    private readonly IDiscountTypeHandler _discountTypeHandler;

    public ProductCouponIntegrationService(IUnitOfWork<ProductDbContext, IProductRepository> unitOfWork,
                                           ICouponHttpClient couponHttpClient, IDiscountTypeHandler discountTypeHandler)
    {
        _couponHttpClient = couponHttpClient;
        _discountTypeHandler = discountTypeHandler;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ProductDto>> ApplyCouponeToProduct(Guid ProductId, string CouponeCode)
        => await Result.Try(async Task<ProductDto> () => await ApplyCouponeToProductAsync(ProductId, CouponeCode));


    private async Task<ProductDto> ApplyCouponeToProductAsync(Guid ProductId, string CouponeCode)
    {
        var productDomain = await _unitOfWork.Repository.GetByIdAsync(ProductId);
        var couponDto = await _couponHttpClient.GetSharedCouponeByCode(CouponeCode);

        if (couponDto == null || productDomain == null)
        {
            throw new Exception(
                $"Apply Coupone to product error: some variablse is null; " +
                $"couponDto: {couponDto} ProductDomain: {productDomain}");
        }

        productDomain = ApplyDiscount(productDomain, couponDto);
        return ProductModelMapper.MapProductModelToProductDto(productDomain);
    }

    private ProductModel ApplyDiscount(ProductModel productDomain, CouponDto couponDto)
    {
        switch (couponDto.DiscountType)
        {
            case nameof(CouponDiscountTypes.Percentage):
                return _discountTypeHandler.ApplyPercentageDiscount(productDomain, couponDto);

            case nameof(CouponDiscountTypes.FixedAmount):
                return _discountTypeHandler.ApplyFixedAmountDiscount(productDomain, couponDto);

            default:
                throw new Exception("Product apply Coupon error: Unhadled Discount Types");
        }
    }

}
