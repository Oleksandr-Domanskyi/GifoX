using System;
using FluentResults;
using Product.Core.Dto;
using Product.Service.Core.ProductDto.Request;

namespace Product.Infrastructure.Services.IServices;

public interface IProductRepositoryServices
{
    Task<Result<IEnumerable<ProductDto>>> GetAll();
    Task<Result<ProductDto>> GetById(Guid Id);
    Task<Result<ProductDto>> AddProduct(ProductRequest model);
    Task<Result<ProductDto>> UpdateProduct(ProductRequest model, Guid ProductId, string UserId);
    Task<Result> DeleteProduct(Guid Id);
}
