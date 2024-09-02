using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Coupons.Service.Core.Domain.Enums;

namespace Coupons.Service.Core.Domain
{
    public class CouponModelConfiguration : IEntityTypeConfiguration<CouponModel>
    {
        public void Configure(EntityTypeBuilder<CouponModel> builder)
        {
            builder.ToTable("Coupons");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                   .HasField("_id")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.CouponCode)
                   .HasField("_couponCode")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("CouponCode");

            builder.Property(c => c.DiscountAmount)
                   .HasField("_discountAmount")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)")
                   .HasColumnName("DiscountAmount");

            builder.Property(c => c.MinAmount)
                   .HasField("_minAmount")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired()
                   .HasColumnName("MinAmount");

            builder.Property(c => c.DiscountType)
                   .HasField("_discountType")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasConversion(
                        v => v,
                        v => v)
                   .HasColumnName("DiscountType");

            builder.Property(c => c.UsableAmount)
                   .HasField("_usableAmount")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired()
                   .HasColumnName("UsableAmount");

            builder.Property(c => c.CanBeUsed)
                   .HasField("_CanBeUsed")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired()
                   .HasColumnName("CanBeUsed");
        }
    }
}
