using System;
using Coupons.Service.Core.Dto;
using Product.Product.Core.Domain;

namespace Product.Infrastructure.Services.IServices.IProductSharedServices.IHandler;

public interface IDiscountTypeHandler
{
    ProductModel ApplyPercentageDiscount(ProductModel productDomain, CouponDto couponDto);
    ProductModel ApplyFixedAmountDiscount(ProductModel productDomain, CouponDto couponeDto);
}
