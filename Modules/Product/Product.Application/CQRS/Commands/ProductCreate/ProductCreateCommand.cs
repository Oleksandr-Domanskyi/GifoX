using System;
using MediatR;
using Product.Core.Dto;
using Product.Service.Core.ProductDto.Request;

namespace Product.Application.CQRS.Commands.ProductCreate;

public class ProductCreateCommand:IRequest<ProductDto>
{
    public ProductRequest ProductRequest{ get; set; }
    public ProductCreateCommand(ProductRequest productRequest)
    {
        ProductRequest = productRequest;
    }
}
