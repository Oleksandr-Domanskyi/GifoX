﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Product.Infrastructure.Database.DbContext;

#nullable disable

namespace Product.Infrastructure.Database.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    partial class ProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Product")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Product.Core.Domain.ClientFeedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("Comment");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedDate");

                    b.Property<string>("ProductAdvantages")
                        .HasColumnType("text")
                        .HasColumnName("ProductAdvantages");

                    b.Property<string>("ProductDisadvantages")
                        .HasColumnType("text")
                        .HasColumnName("ProductDisadvantages");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("ProductId");

                    b.Property<Guid?>("ProductModelId")
                        .HasColumnType("uuid");

                    b.Property<double>("Raiting")
                        .HasColumnType("decimal(3,2)")
                        .HasColumnName("Raiting");

                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProductModelId");

                    b.ToTable("ClientFeedbacks", "Product");
                });

            modelBuilder.Entity("Product.Service.Core.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasMaxLength(50)
                        .HasColumnType("uuid")
                        .HasColumnName("ProductId");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("Url");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images", "Product");
                });

            modelBuilder.Entity("Product.Service.Core.Domain.ProductModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Category");

                    b.Property<string>("Characteristics")
                        .HasColumnType("text")
                        .HasColumnName("Characteristics");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedDate");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("Description");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("EndDate");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<double>("PrBrutto")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("PrBrutto");

                    b.Property<double>("PrNetto")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("PrNetto");

                    b.Property<string>("SubCategory")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("SubCategory");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("Products", "Product");
                });

            modelBuilder.Entity("Product.Core.Domain.ClientFeedback", b =>
                {
                    b.HasOne("Product.Service.Core.Domain.ProductModel", null)
                        .WithMany("ClientFeedbacks")
                        .HasForeignKey("ProductModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Product.Service.Core.Domain.Image", b =>
                {
                    b.HasOne("Product.Service.Core.Domain.ProductModel", null)
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Product.Service.Core.Domain.ProductModel", b =>
                {
                    b.Navigation("ClientFeedbacks");

                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
