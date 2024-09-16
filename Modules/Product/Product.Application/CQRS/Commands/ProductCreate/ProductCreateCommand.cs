using System;
using MediatR;
using Product.Service.Core.ProductDto.Request;
using Shared.Core.ProductShared.Dto;

namespace Product.Application.CQRS.Commands.ProductCreate;

public class ProductCreateCommand : IRequest<ProductDto>
{
    public ProductRequest ProductRequest { get; set; }
    public ProductCreateCommand(ProductRequest productRequest)
    {
        ProductRequest = productRequest;
    }
}
