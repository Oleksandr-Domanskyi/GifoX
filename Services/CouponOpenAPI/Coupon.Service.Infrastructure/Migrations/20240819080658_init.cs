using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coupons.Service.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CouponCode = table.Column<string>(type: "text", nullable: false),
                    DiscountAmount = table.Column<double>(type: "double precision", nullable: false),
                    MinAmount = table.Column<int>(type: "integer", nullable: false),
                    DiscountType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupon");
        }
    }
}
