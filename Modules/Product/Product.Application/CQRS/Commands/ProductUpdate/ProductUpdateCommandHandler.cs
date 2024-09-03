using System;
using MediatR;
using Product.Core.Dto;
using Product.Infrastructure.Services.IServices;

namespace Product.Application.CQRS.Commands.ProductUpdate;

public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, ProductDto>
{
    private readonly IProductRepositoryServices _productRepositoryServices;
    public ProductUpdateCommandHandler(IProductRepositoryServices productRepositoryServices)
    {
        _productRepositoryServices = productRepositoryServices;
    }
    public async Task<ProductDto> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        var model = await _productRepositoryServices.UpdateProduct(request.ProductRequest, request.Id, Guid.NewGuid().ToString());
        if (model.IsSuccess)
        {
            return model.Value;
        }
        throw new Exception(string.Join(", ", model.Errors.Select(x => x.Message)));
    }
}
