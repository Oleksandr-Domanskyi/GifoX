using System;
using MediatR;
using Product.Core.Dto;

namespace Product.Application.CQRS.Queries.ProductGetAll;

public class ProductGetAllQueryHandler : IRequestHandler<ProductGetAllQuery, IEnumerable<ProductDto>>
{
    public Task<IEnumerable<ProductDto>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
