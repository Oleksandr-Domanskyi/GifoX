using System;
using MediatR;
using Product.Core.Dto;
using Product.Infrastructure.Services.IServices;
using Shared.Core.ProductShared.Dto;

namespace Product.Application.CQRS.Queries.ProductGetAll;

public class ProductGetAllQueryHandler : IRequestHandler<ProductGetAllQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepositoryServices _productRepositoryServices;

    public ProductGetAllQueryHandler(IProductRepositoryServices productRepositoryServices)
    {
        _productRepositoryServices = productRepositoryServices;
    }
    public async Task<IEnumerable<ProductDto>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
    {
        var model = await _productRepositoryServices.GetAll();
        if (model.IsSuccess)
        {
            return model.Value;
        }
        throw new Exception(string.Join(",", model.Errors.Select(error => error.Message)));
    }
}
