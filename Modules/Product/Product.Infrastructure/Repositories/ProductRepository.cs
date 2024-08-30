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

    public async Task CreateAsync(ProductModel productModel)
        => await _dbContext.Products.AddAsync(productModel);

    // Add Filters
    public async Task<IEnumerable<ProductModel>> GetAllAsync()
        => await _dbContext.Products.ToListAsync();
    public async Task<ProductModel?> GetByIdAsync(Guid id)
        => await _dbContext.Products.FirstOrDefaultAsync(src => src.Id == id);
    public Task UpdateAsync(ProductModel productModel)
    {
        _dbContext.Products.Update(productModel);
        return Task.CompletedTask;
    }
    public Task Delete(ProductModel productModel)
    {
        _dbContext.Products.Remove(productModel);
        return Task.CompletedTask;
    }
}
