using System;
using MediatR;
using Product.Core.Dto;
using Product.Infrastructure.Services.IServices;
using Product.Infrastructure.Services.IServices.IProductSharedServices;
using Shared.Core.ProductShared.Dto;

namespace Product.Application.CQRS.Commands.ProductApplyCoupon;

public class ProductApplyCouponCommandHandler : IRequestHandler<ProductApplyCouponCommand, ProductDto>
{
    private readonly IProductCouponIntegrationService _productCouponIntegrationService;

    public ProductApplyCouponCommandHandler(IProductCouponIntegrationService productCouponIntegrationService)
    {
        _productCouponIntegrationService = productCouponIntegrationService;
    }
    public async Task<ProductDto> Handle(ProductApplyCouponCommand request, CancellationToken cancellationToken)
    {
        var model = await _productCouponIntegrationService.ApplyCouponeToProduct(request.ProductId, request.CouponCode);
        if (model.IsSuccess)
        {
            return model.Value;
        }
        throw new Exception(string.Join(", ", model.Errors.Select(e => e.Message)));
    }
}
