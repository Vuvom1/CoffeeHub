using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeHub.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIngredientStockQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("477f90c6-a1ab-4fda-a83d-7e812c6d1c47"));

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("cc25706b-f66a-4c26-8e7b-e09f10937570"));

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("ed478375-66d6-48b7-b733-d59fbd718e46"));

            migrationBuilder.AlterColumn<int>(
                name: "UnitOfMeasurement",
                table: "Ingredients",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalQuantity",
                table: "Ingredients",
                type: "decimal(18,2)",
                maxLength: 50,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "0");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UnitOfMeasurement",
                table: "Ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "TotalQuantity",
                table: "Ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "0",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 50,
                oldDefaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 16, 18, 20, 48, 810, DateTimeKind.Local).AddTicks(1160), new DateTime(2025, 3, 16, 18, 20, 48, 810, DateTimeKind.Local).AddTicks(1170) });

            migrationBuilder.UpdateData(
                table: "Auths",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 16, 18, 20, 48, 810, DateTimeKind.Local).AddTicks(2290), new DateTime(2025, 3, 16, 18, 20, 48, 810, DateTimeKind.Local).AddTicks(2290) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 16, 18, 20, 48, 810, DateTimeKind.Local).AddTicks(190), new DateTime(2025, 3, 16, 18, 20, 48, 810, DateTimeKind.Local).AddTicks(190) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 16, 18, 20, 48, 798, DateTimeKind.Local).AddTicks(5690), new DateTime(2025, 3, 16, 18, 20, 48, 809, DateTimeKind.Local).AddTicks(4880) });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "CreatedAt", "EndTime", "Name", "StartTime", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("477f90c6-a1ab-4fda-a83d-7e812c6d1c47"), new DateTime(2025, 3, 16, 18, 20, 48, 810, DateTimeKind.Local).AddTicks(3560), new TimeSpan(0, 12, 0, 0, 0), "Morning Shift", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 3, 16, 18, 20, 48, 810, DateTimeKind.Local).AddTicks(3560) },
                    { new Guid("cc25706b-f66a-4c26-8e7b-e09f10937570"), new DateTime(2025, 3, 16, 18, 20, 48, 810, DateTimeKind.Local).AddTicks(3970), new TimeSpan(0, 22, 0, 0, 0), "Evening Shift", new TimeSpan(0, 18, 0, 0, 0), new DateTime(2025, 3, 16, 18, 20, 48, 810, DateTimeKind.Local).AddTicks(3970) },
                    { new Guid("ed478375-66d6-48b7-b733-d59fbd718e46"), new DateTime(2025, 3, 16, 18, 20, 48, 810, DateTimeKind.Local).AddTicks(3960), new TimeSpan(0, 18, 0, 0, 0), "Afternoon Shift", new TimeSpan(0, 12, 0, 0, 0), new DateTime(2025, 3, 16, 18, 20, 48, 810, DateTimeKind.Local).AddTicks(3960) }
                });
        }
    }
}
