using System;
using Coupons.Service.Core.Dto;
using Product.Infrastructure.Services.IServices.IProductSharedServices.IHandler;
using Product.Product.Core.Domain;

namespace Shared.Core.CouponShared.Handlers;


// Неправильна обробка процентів та сталої ціни.
// До направи
public class DiscountTypeHandler : IDiscountTypeHandler
{
    public ProductModel ApplyPercentageDiscount(ProductModel productDomain, CouponDto couponDto)
    {
        
        if (couponDto.DiscountAmount < 0 || couponDto.DiscountAmount > 100)
        {
            throw new ArgumentException("Invalid discount percentage.");
        }

        productDomain.PrNetto -= productDomain.PrNetto * (couponDto.DiscountAmount / 100);
        productDomain.PrBrutto -= productDomain.PrBrutto * (couponDto.DiscountAmount / 100);

        return productDomain;
    }

    public ProductModel ApplyFixedAmountDiscount(ProductModel productDomain, CouponDto couponeDto)
    {
        if (couponeDto.DiscountAmount < 0)
        {
            throw new ArgumentException("Invalid discount amount.");
        }

        productDomain.PrNetto -= couponeDto.DiscountAmount;
        productDomain.PrBrutto -= couponeDto.DiscountAmount;

        productDomain.PrNetto = productDomain.PrNetto < 0 ? 0 : productDomain.PrNetto;
        productDomain.PrBrutto = productDomain.PrBrutto < 0 ? 0 : productDomain.PrBrutto;

        return productDomain;
    }
}
