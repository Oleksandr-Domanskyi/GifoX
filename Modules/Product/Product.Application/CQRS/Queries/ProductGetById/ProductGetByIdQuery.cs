using System;
using MediatR;
using Product.Core.Dto;
using Shared.Core.ProductShared.Dto;

namespace Product.Application.CQRS.Queries.ProductGetById;

public class ProductGetByIdQuery : IRequest<ProductDto>
{
    public Guid Id { get; set; }
    public ProductGetByIdQuery(Guid id)
    {
        Id = id;
    }
}
