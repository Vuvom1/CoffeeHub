using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeHub.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerLevelAndRemoveType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PromotionType",
                table: "Promotions",
                newName: "CustomerLevel");

            migrationBuilder.RenameColumn(
                name: "DiscountValue",
                table: "Promotions",
                newName: "DiscountRate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscountRate",
                table: "Promotions",
                newName: "DiscountValue");

            migrationBuilder.RenameColumn(
                name: "CustomerLevel",
                table: "Promotions",
                newName: "PromotionType");
        }
    }
}
