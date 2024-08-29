using System;
using Microsoft.EntityFrameworkCore;
using Product.Core.Domain;
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
        modelBuilder.Entity<ProductModel>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<ProductModel>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<ProductModel>()
            .Property(p => p.PrBrutto);

        modelBuilder.Entity<ProductModel>()
            .Property(p => p.Category)
            .HasConversion(
                v => v.ToString(),
                v => (MainCategory)Enum.Parse(typeof(MainCategory), v));

        modelBuilder.Entity<ProductModel>()
            .Property(p => p.SubCategory)
            .HasConversion(
                v => v.ToString(),
                v => (SubMainCategory)Enum.Parse(typeof(SubMainCategory), v));


        modelBuilder.Entity<ClientFeedback>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<ClientFeedback>()
          .Property(p => p.Id)
          .ValueGeneratedOnAdd();

        base.OnModelCreating(modelBuilder);
    }
}
