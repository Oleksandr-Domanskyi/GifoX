using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Product.Core.Domain
{
    public class ClientFeedbackConfiguration : IEntityTypeConfiguration<ClientFeedback>
    {
        public void Configure(EntityTypeBuilder<ClientFeedback> builder)
        {

            builder.ToTable("ClientFeedbacks");


            builder.HasKey(cf => cf.Id);
            builder.Property(cf => cf.Id)
                   .HasField("_Id")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .ValueGeneratedOnAdd();

            builder.Property(cf => cf.Raiting)
                   .HasField("_Raiting")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired()
                   .HasColumnType("decimal(3,2)")
                   .HasColumnName("Raiting");

            builder.Property(cf => cf.Comment)
                   .HasField("_Comment")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .HasMaxLength(1000)
                   .HasColumnName("Comment");

            builder.Property(cf => cf.ProductAdvantages)
                   .HasField("_ProductAdvantages")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .HasConversion(
                        v => string.Join(";", v!),
                        v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList()
                    )
                   .HasColumnName("ProductAdvantages");

            builder.Property(cf => cf.ProductDisadvantages)
                   .HasField("_ProductDisadvantages")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .HasConversion(
                        v => string.Join(";", v!),
                        v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList()
                    )
                   .HasColumnName("ProductDisadvantages");

            builder.Property(cf => cf.CreatedDate)
                   .HasField("_CreatedDate")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired()
                   .HasColumnName("CreatedDate");

            builder.Property(cf => cf.ProductId)
                   .HasField("_ProductId")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .HasColumnName("ProductId");

            builder.Property(cf => cf.UserId)
                   .HasField("_UserId")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .HasColumnName("UserId");
        }
    }
}
