using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class ProductConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientFeedbacks_Products_ProductModelId",
                schema: "Product",
                table: "ClientFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_ProductModelId",
                schema: "Product",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ProductModelId",
                schema: "Product",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ProductModelId",
                schema: "Product",
                table: "Images");

            migrationBuilder.AlterColumn<double>(
                name: "PrNetto",
                schema: "Product",
                table: "Products",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "PrBrutto",
                schema: "Product",
                table: "Products",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<string>(
                name: "Characteristics",
                schema: "Product",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(List<string>),
                oldType: "text[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                schema: "Product",
                table: "Images",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                schema: "Product",
                table: "Images",
                type: "uuid",
                maxLength: 50,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Raiting",
                schema: "Product",
                table: "ClientFeedbacks",
                type: "numeric(3,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<string>(
                name: "ProductDisadvantages",
                schema: "Product",
                table: "ClientFeedbacks",
                type: "text",
                nullable: true,
                oldClrType: typeof(List<string>),
                oldType: "text[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductAdvantages",
                schema: "Product",
                table: "ClientFeedbacks",
                type: "text",
                nullable: true,
                oldClrType: typeof(List<string>),
                oldType: "text[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                schema: "Product",
                table: "ClientFeedbacks",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                schema: "Product",
                table: "Images",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientFeedbacks_Products_ProductModelId",
                schema: "Product",
                table: "ClientFeedbacks",
                column: "ProductModelId",
                principalSchema: "Product",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_ProductId",
                schema: "Product",
                table: "Images",
                column: "ProductId",
                principalSchema: "Product",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientFeedbacks_Products_ProductModelId",
                schema: "Product",
                table: "ClientFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_ProductId",
                schema: "Product",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ProductId",
                schema: "Product",
                table: "Images");

            migrationBuilder.AlterColumn<double>(
                name: "PrNetto",
                schema: "Product",
                table: "Products",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "PrBrutto",
                schema: "Product",
                table: "Products",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<List<string>>(
                name: "Characteristics",
                schema: "Product",
                table: "Products",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                schema: "Product",
                table: "Images",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                schema: "Product",
                table: "Images",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductModelId",
                schema: "Product",
                table: "Images",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Raiting",
                schema: "Product",
                table: "ClientFeedbacks",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "numeric(3,2)");

            migrationBuilder.AlterColumn<List<string>>(
                name: "ProductDisadvantages",
                schema: "Product",
                table: "ClientFeedbacks",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<List<string>>(
                name: "ProductAdvantages",
                schema: "Product",
                table: "ClientFeedbacks",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                schema: "Product",
                table: "ClientFeedbacks",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductModelId",
                schema: "Product",
                table: "Images",
                column: "ProductModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientFeedbacks_Products_ProductModelId",
                schema: "Product",
                table: "ClientFeedbacks",
                column: "ProductModelId",
                principalSchema: "Product",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_ProductModelId",
                schema: "Product",
                table: "Images",
                column: "ProductModelId",
                principalSchema: "Product",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
