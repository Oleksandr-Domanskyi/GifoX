using System;
using FluentResults;
using Product.Core.Dto;
using Product.Infrastructure.Database.DbContext;
using Product.Infrastructure.Repositories.IRepositories;
using Product.Infrastructure.Services.IServices;
using Product.Service.Core.ProductDto.Request;
using Shared.Shared.Infrastructure.UnitOfWork;
using Product.Product.Infrastructure.CustomMapper;

namespace Product.Infrastructure.Services.ProductRepositoryServices;

public class ProductRepositoryServices : IProductRepositoryServices
{
    private readonly IUnitOfWork<ProductDbContext, IProductRepository> _unitOfWork;

    public ProductRepositoryServices(IUnitOfWork<ProductDbContext, IProductRepository> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> AddProduct(ProductRequest model)
        => await Result.Try(async Task () => await AddProductAsync(model));
    public async Task<Result> DeleteProduct(Guid Id)
        => await Result.Try(async Task () => await DeleteProductAsync(Id));
    public async Task<Result<IEnumerable<ProductDto>>> GetAll()
        => await Result.Try(async Task<IEnumerable<ProductDto>> () => await GetAllProductAsync());
    public async Task<Result<ProductDto>> GetById(Guid Id)
        => await Result.Try(async Task<ProductDto> () => await GetByIdProductAsync(Id));
    public async Task<Result<ProductDto>> UpdateProduct(ProductRequest model, Guid ProductId, string UserId)
        => await Result.Try(async Task<ProductDto> () => await UpdateProductAsync(model, ProductId, UserId));


    private async Task<ProductDto> AddProductAsync(ProductRequest model)
    {
        var domain = ProductModelMapper.MapProductRequestToProductModel(model, Guid.NewGuid().ToString());

        domain = await _unitOfWork.Repository.CreateAsync(domain);
        await _unitOfWork.SaveChangesAsync();

        return ProductModelMapper.MapProductModelToProductDto(domain);
    }

    private async Task DeleteProductAsync(Guid Id)
    {
        await _unitOfWork.Repository.DeleteAsync(Id);
        await _unitOfWork.SaveChangesAsync();
    }

    private async Task<IEnumerable<ProductDto>> GetAllProductAsync()
    {
        var model = await _unitOfWork.Repository.GetAllAsync();
        return ProductModelMapper.MapProductModelToProductDto(model);
    }

    private async Task<ProductDto> GetByIdProductAsync(Guid Id)
    {
        var model = await _unitOfWork.Repository.GetByIdAsync(Id);
        return ProductModelMapper.MapProductModelToProductDto(model);
    }
    private async Task<ProductDto> UpdateProductAsync(ProductRequest model, Guid ProductId, string UserId)
    {
        var entity = ProductModelMapper.MapProductRequestToProductModel(model, ProductId, UserId);

        var result = _unitOfWork.Repository.UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        return ProductModelMapper.MapProductModelToProductDto(result);

    }
}
