using System;
using MediatR;
using Product.Core.Dto;
using Product.Service.Core.ProductDto.Request;

namespace Product.Application.CQRS.Commands.ProductUpdate;

public class ProductUpdateCommand : IRequest<ProductDto>
{
    public ProductRequest ProductRequest { get; set; }
    public Guid Id { get; set; }
    public ProductUpdateCommand(ProductRequest productRequest, Guid id)
    {
        ProductRequest = productRequest;
        Id = id;
    }
}
