using System;
using MediatR;
using Product.Core.Dto;
using Product.Infrastructure.Services.IServices;

namespace Product.Application.CQRS.Commands.ProductCreate;

public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, ProductDto>
{
    private readonly IProductRepositoryServices _productRepositoryServices;
    public ProductCreateCommandHandler(IProductRepositoryServices productRepositoryServices)
    {
        _productRepositoryServices = productRepositoryServices;

    }
    public async Task<ProductDto> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        var model = await _productRepositoryServices.AddProduct(request.ProductRequest);
        if (model.IsSuccess)
        {
            return model.Value;
        }
        throw new Exception(string.Join(", ", model.Errors.Select(x => x.Message)));
    }
}
