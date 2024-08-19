using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coupons.Service.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CQRSChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanBeUsed",
                table: "Coupon",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UsableAmount",
                table: "Coupon",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanBeUsed",
                table: "Coupon");

            migrationBuilder.DropColumn(
                name: "UsableAmount",
                table: "Coupon");
        }
    }
}
