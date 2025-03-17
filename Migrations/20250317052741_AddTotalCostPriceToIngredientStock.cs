using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeHub.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalCostPriceToIngredientStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("09456c51-e73e-4c93-b443-e96e373ccf97"));

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("3db88c22-3d11-45a3-a51d-690ebee77bd8"));

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("81ec7d44-3ce7-4d9b-9ad3-ed983fd79feb"));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCostPrice",
                table: "IngredientStocks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 17, 12, 27, 40, 957, DateTimeKind.Local).AddTicks(3080), new DateTime(2025, 3, 17, 12, 27, 40, 957, DateTimeKind.Local).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "Auths",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 17, 12, 27, 40, 957, DateTimeKind.Local).AddTicks(4250), new DateTime(2025, 3, 17, 12, 27, 40, 957, DateTimeKind.Local).AddTicks(4250) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 17, 12, 27, 40, 957, DateTimeKind.Local).AddTicks(1900), new DateTime(2025, 3, 17, 12, 27, 40, 957, DateTimeKind.Local).AddTicks(1910) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 17, 12, 27, 40, 944, DateTimeKind.Local).AddTicks(9490), new DateTime(2025, 3, 17, 12, 27, 40, 956, DateTimeKind.Local).AddTicks(5060) });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "CreatedAt", "EndTime", "Name", "StartTime", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("74370603-af2f-4115-bc65-1dda7e1f74a2"), new DateTime(2025, 3, 17, 12, 27, 40, 957, DateTimeKind.Local).AddTicks(5600), new TimeSpan(0, 12, 0, 0, 0), "Morning Shift", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 3, 17, 12, 27, 40, 957, DateTimeKind.Local).AddTicks(5610) },
                    { new Guid("a3197be9-7070-48b6-ad2f-271e10fadd8e"), new DateTime(2025, 3, 17, 12, 27, 40, 957, DateTimeKind.Local).AddTicks(6020), new TimeSpan(0, 18, 0, 0, 0), "Afternoon Shift", new TimeSpan(0, 12, 0, 0, 0), new DateTime(2025, 3, 17, 12, 27, 40, 957, DateTimeKind.Local).AddTicks(6030) },
                    { new Guid("c1a0c9f8-5bac-4fd2-ba0c-90f361998948"), new DateTime(2025, 3, 17, 12, 27, 40, 957, DateTimeKind.Local).AddTicks(6040), new TimeSpan(0, 22, 0, 0, 0), "Evening Shift", new TimeSpan(0, 18, 0, 0, 0), new DateTime(2025, 3, 17, 12, 27, 40, 957, DateTimeKind.Local).AddTicks(6040) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("74370603-af2f-4115-bc65-1dda7e1f74a2"));

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("a3197be9-7070-48b6-ad2f-271e10fadd8e"));

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("c1a0c9f8-5bac-4fd2-ba0c-90f361998948"));

            migrationBuilder.DropColumn(
                name: "TotalCostPrice",
                table: "IngredientStocks");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 17, 11, 24, 34, 616, DateTimeKind.Local).AddTicks(5860), new DateTime(2025, 3, 17, 11, 24, 34, 616, DateTimeKind.Local).AddTicks(5860) });

            migrationBuilder.UpdateData(
                table: "Auths",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 17, 11, 24, 34, 616, DateTimeKind.Local).AddTicks(6910), new DateTime(2025, 3, 17, 11, 24, 34, 616, DateTimeKind.Local).AddTicks(6920) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 17, 11, 24, 34, 616, DateTimeKind.Local).AddTicks(4860), new DateTime(2025, 3, 17, 11, 24, 34, 616, DateTimeKind.Local).AddTicks(4870) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 17, 11, 24, 34, 604, DateTimeKind.Local).AddTicks(9670), new DateTime(2025, 3, 17, 11, 24, 34, 615, DateTimeKind.Local).AddTicks(9810) });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "CreatedAt", "EndTime", "Name", "StartTime", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("09456c51-e73e-4c93-b443-e96e373ccf97"), new DateTime(2025, 3, 17, 11, 24, 34, 616, DateTimeKind.Local).AddTicks(8550), new TimeSpan(0, 18, 0, 0, 0), "Afternoon Shift", new TimeSpan(0, 12, 0, 0, 0), new DateTime(2025, 3, 17, 11, 24, 34, 616, DateTimeKind.Local).AddTicks(8560) },
                    { new Guid("3db88c22-3d11-45a3-a51d-690ebee77bd8"), new DateTime(2025, 3, 17, 11, 24, 34, 616, DateTimeKind.Local).AddTicks(8160), new TimeSpan(0, 12, 0, 0, 0), "Morning Shift", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 3, 17, 11, 24, 34, 616, DateTimeKind.Local).AddTicks(8160) },
                    { new Guid("81ec7d44-3ce7-4d9b-9ad3-ed983fd79feb"), new DateTime(2025, 3, 17, 11, 24, 34, 616, DateTimeKind.Local).AddTicks(8560), new TimeSpan(0, 22, 0, 0, 0), "Evening Shift", new TimeSpan(0, 18, 0, 0, 0), new DateTime(2025, 3, 17, 11, 24, 34, 616, DateTimeKind.Local).AddTicks(8560) }
                });
        }
    }
}
