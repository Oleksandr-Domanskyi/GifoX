using System;
using MediatR;
using Product.Infrastructure.Services.IServices;

namespace Product.Application.CQRS.Commands.ProductDelete;

public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand>
{
    private readonly IProductRepositoryServices _productRepositoryServices;

    public ProductDeleteCommandHandler(IProductRepositoryServices productRepositoryServices)
    {
        _productRepositoryServices = productRepositoryServices;
    }
    public async Task Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
    {
        var model = await _productRepositoryServices.DeleteProduct(request.Id);
        if (model.IsSuccess){
            
        }
        throw new Exception(string.Join(", ", model.Errors.Select(e => e.Message)));
    }
}
