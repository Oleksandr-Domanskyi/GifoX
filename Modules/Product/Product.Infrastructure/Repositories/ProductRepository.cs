using System;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using Product.Infrastructure.Database.DbContext;
using Product.Infrastructure.Repositories.IRepositories;
using Product.Service.Core.Domain;

namespace Product.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _dbContext;

    public ProductRepository(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Add Filters
    public async Task<IEnumerable<ProductModel>> GetAllAsync()
        => await _dbContext.Products.ToListAsync();
    public async Task<ProductModel> GetByIdAsync(Guid id)
        => await _dbContext.Products.FirstAsync(src => src.Id == id);
    public async Task<ProductModel> CreateAsync(ProductModel productModel)
    {
        await _dbContext.Products.AddAsync(productModel);
        return productModel;
    }
    public ProductModel UpdateAsync(ProductModel productModel)
    {
        _dbContext.Products.Update(productModel);
        return productModel;
    }
    public async Task DeleteAsync(Guid Id)
    {
        var model = await _dbContext.Products.FirstAsync(src => src.Id == Id);
        _dbContext.Products.Remove(model);
    }
}
