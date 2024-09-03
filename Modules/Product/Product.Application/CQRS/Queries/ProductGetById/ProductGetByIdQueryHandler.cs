using System;
using MediatR;
using Product.Core.Dto;
using Product.Infrastructure.Services.IServices;

namespace Product.Application.CQRS.Queries.ProductGetById;

public class ProductGetByIdQueryHandler : IRequestHandler<ProductGetByIdQuery, ProductDto>
{
    private readonly IProductRepositoryServices _productRepositoryServices;
    public ProductGetByIdQueryHandler(IProductRepositoryServices productRepositoryServices)
    {
        _productRepositoryServices = productRepositoryServices;
    }
    public async Task<ProductDto> Handle(ProductGetByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _productRepositoryServices.GetById(request.Id);
        if (model.IsSuccess)
        {
            return model.Value;
        }
        throw new Exception(string.Join(", ", model.Errors.Select(e => e.Message)));
    }
}
