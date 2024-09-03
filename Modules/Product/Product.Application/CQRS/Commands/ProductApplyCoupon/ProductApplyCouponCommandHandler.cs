using System;
using MediatR;
using Product.Core.Dto;
using Product.Infrastructure.Services.IServices;

namespace Product.Application.CQRS.Commands.ProductApplyCoupon;

public class ProductApplyCouponCommandHandler : IRequestHandler<ProductApplyCouponCommand, ProductDto>
{
    private readonly IProductRepositoryServices _productRepositoryServices;
    public ProductApplyCouponCommandHandler(IProductRepositoryServices productRepositoryServices)
    {
        _productRepositoryServices = productRepositoryServices;

    }
    public async Task<ProductDto> Handle(ProductApplyCouponCommand request, CancellationToken cancellationToken)
    {
        var model = await _productRepositoryServices.ApplyCouponetoProduct(request.ProductId, request.CouponCode);
        if(model.IsSuccess){
            return model.Value;
        }
        throw new Exception(string.Join(", ", model.Errors.Select(e => e.Message)));
    }
}
