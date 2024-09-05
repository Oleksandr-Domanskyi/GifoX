using System;
using Product.Product.Core.Domain;
using Shared.Infrastructure.RepositoriesManager;

namespace Product.Infrastructure.Repositories.IRepositories;

public interface IProductRepository : IRepository
{
    Task<IEnumerable<ProductModel>> GetAllAsync();
    Task<ProductModel> GetByIdAsync(Guid id);
    ProductModel UpdateAsync(ProductModel productModel);
    Task<ProductModel> CreateAsync(ProductModel productModel);
    Task DeleteAsync(Guid Id);

}
