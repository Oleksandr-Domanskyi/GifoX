using System;
using Microsoft.EntityFrameworkCore;
using Product.Core.Domain;
using Product.Product.Core.Domain;
using Product.Service.Core.Domain;
using Shared.Infrastructure.Database;
using static Product.Service.Core.Domain.Enums.Category;

namespace Product.Infrastructure.Database.DbContext;

public class ProductDbContext : ModuleDbContext
{
    protected override string Schema => "Product";

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {

    }
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<ClientFeedback> ClientFeedbacks { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
