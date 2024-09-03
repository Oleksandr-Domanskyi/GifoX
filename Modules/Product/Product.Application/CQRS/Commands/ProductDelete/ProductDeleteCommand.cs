using System;
using MediatR;

namespace Product.Application.CQRS.Commands.ProductDelete;

public class ProductDeleteCommand:IRequest
{
    public Guid Id { get; set; }
    public ProductDeleteCommand(Guid id)
    {
        Id = id;
    }
}
