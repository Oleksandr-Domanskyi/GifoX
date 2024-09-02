using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Product.Service.Core.Domain
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
                   .HasField("_Id")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .ValueGeneratedOnAdd();

            builder.Property(i => i.Url)
                   .HasField("_Url")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired()
                   .HasMaxLength(500)
                   .HasColumnName("Url");

            builder.Property(i => i.ProductId)
                   .HasField("_ProductId")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .HasMaxLength(50)
                   .HasColumnName("ProductId");
        }
    }
}
