using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Product.Service.Core.Domain.Enums.Category;

namespace Product.Service.Core.Domain
{
    public class ProductModelConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                   .HasField("_Id")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasField("_Name")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired()
                   .HasColumnName("Name");

            builder.Property(p => p.Description)
                   .HasField("_Description")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .HasColumnName("Description");

            builder.Property(p => p.Characteristics)
                   .HasField("_Characteristics")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .HasConversion(
                        v => string.Join(";", v!),
                        v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList()
                    )
                   .HasColumnName("Characteristics");

            builder.HasMany(p => p.Images)
                   .WithOne()
                   .HasForeignKey(i => i.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Category)
                   .HasField("_Category")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired()
                   .HasConversion(
                        v => v.ToString(),
                        v => (MainCategory)Enum.Parse(typeof(MainCategory), v))
                   .HasColumnName("Category");

            builder.Property(p => p.SubCategory)
                   .HasField("_SubCategory")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired()
                   .HasConversion(
                        v => v.ToString(),
                        v => (SubMainCategory)Enum.Parse(typeof(SubMainCategory), v))
                   .HasColumnName("SubCategory");

            builder.Property(p => p.PrNetto)
                   .HasField("_PrNetto")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)")
                   .HasColumnName("PrNetto");

            builder.Property(p => p.PrBrutto)
                   .HasField("_PrBrutto")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .HasColumnType("decimal(18,2)")
                   .HasColumnName("PrBrutto");

            builder.HasMany(p => p.ClientFeedbacks)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.IsActive)
                   .HasField("_IsActive")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired()
                   .HasColumnName("IsActive");

            builder.Property(p => p.CreatedDate)
                   .HasField("_CreatedDate")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired()
                   .HasColumnName("CreatedDate");

            builder.Property(p => p.EndDate)
                   .HasField("_EndDate")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .HasColumnName("EndDate");

            builder.Property(p => p.UserId)
                   .HasField("_UserId")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired()
                   .HasColumnName("UserId");
        }
    }
}
