using System;
using MediatR;
using Product.Core.Dto;

namespace Product.Application.CQRS.Commands.ProductApplyCoupon;

public class ProductApplyCouponCommand : IRequest<ProductDto>
{
    public Guid ProductId { get; set; }
    public string CouponCode { get; set; }
    public ProductApplyCouponCommand(Guid productId, string couponeCode)
    {
        ProductId = productId;
        CouponCode = couponeCode;
    }

}
