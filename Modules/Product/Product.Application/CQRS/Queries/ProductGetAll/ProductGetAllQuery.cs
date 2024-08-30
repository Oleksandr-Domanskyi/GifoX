using System;
using MediatR;
using Product.Core.Dto;

namespace Product.Application.CQRS.Queries.ProductGetAll;

public class ProductGetAllQuery:IRequest<IEnumerable<ProductDto>>
{
    
}
