using System;
using Product.Service.Core.Domain;

namespace Product.Infrastructure.Repositories.IRepositories;

public interface IProductRepository
{
    Task<IEnumerable<ProductModel>> GetAllAsync();
    Task<ProductModel?> GetByIdAsync(Guid id);
    Task UpdateAsync(ProductModel productModel);
    Task CreateAsync(ProductModel productModel);
    Task Delete(ProductModel productModel);
}
