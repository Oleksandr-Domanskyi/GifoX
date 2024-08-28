﻿// <auto-generated />
using System;
using Coupons.Service.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Coupons.Service.Infrastructure.Migrations
{
    [DbContext(typeof(CouponeDbContext))]
    [Migration("20240828180105_Changes Architecture")]
    partial class ChangesArchitecture
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Coupone")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Coupons.Service.Core.Domain.CouponModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("CanBeUsed")
                        .HasColumnType("boolean");

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("double precision");

                    b.Property<string>("DiscountType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MinAmount")
                        .HasColumnType("integer");

                    b.Property<int>("UsableAmount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Coupon", "Coupone");
                });
#pragma warning restore 612, 618
        }
    }
}
