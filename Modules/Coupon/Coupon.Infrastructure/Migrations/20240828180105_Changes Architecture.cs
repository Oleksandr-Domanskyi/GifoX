using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coupons.Service.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangesArchitecture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Coupone");

            migrationBuilder.RenameTable(
                name: "Coupon",
                newName: "Coupon",
                newSchema: "Coupone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Coupon",
                schema: "Coupone",
                newName: "Coupon");
        }
    }
}
