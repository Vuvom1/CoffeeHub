using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeHub.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageUrlCustomerAdminEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("203945cd-7d82-48d9-8e23-54f810d4709d"));

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("bc774cbb-a6a4-4612-b8c0-991b80d74f04"));

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("d7d4295b-fdde-4b7e-8b61-98cde850c9e9"));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 22, 14, 12, 20, 250, DateTimeKind.Local).AddTicks(2230), null, new DateTime(2025, 3, 22, 14, 12, 20, 250, DateTimeKind.Local).AddTicks(2230) });

            migrationBuilder.UpdateData(
                table: "Auths",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 22, 14, 12, 20, 238, DateTimeKind.Local).AddTicks(1450), new DateTime(2025, 3, 22, 14, 12, 20, 249, DateTimeKind.Local).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "Auths",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 22, 14, 12, 20, 249, DateTimeKind.Local).AddTicks(2690), new DateTime(2025, 3, 22, 14, 12, 20, 249, DateTimeKind.Local).AddTicks(2700) });

            migrationBuilder.UpdateData(
                table: "Auths",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 22, 14, 12, 20, 249, DateTimeKind.Local).AddTicks(2700), new DateTime(2025, 3, 22, 14, 12, 20, 249, DateTimeKind.Local).AddTicks(2710) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 22, 14, 12, 20, 250, DateTimeKind.Local).AddTicks(1210), null, new DateTime(2025, 3, 22, 14, 12, 20, 250, DateTimeKind.Local).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 22, 14, 12, 20, 249, DateTimeKind.Local).AddTicks(9750), null, new DateTime(2025, 3, 22, 14, 12, 20, 249, DateTimeKind.Local).AddTicks(9760) });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "CreatedAt", "EndTime", "Name", "StartTime", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0771b96d-4e7f-47d8-b440-695fe10389dc"), new DateTime(2025, 3, 22, 14, 12, 20, 250, DateTimeKind.Local).AddTicks(3730), new TimeSpan(0, 18, 0, 0, 0), "Afternoon Shift", new TimeSpan(0, 12, 0, 0, 0), new DateTime(2025, 3, 22, 14, 12, 20, 250, DateTimeKind.Local).AddTicks(3730) },
                    { new Guid("6ee8ee0d-13f7-4d51-9a57-58dc4a77f625"), new DateTime(2025, 3, 22, 14, 12, 20, 250, DateTimeKind.Local).AddTicks(3740), new TimeSpan(0, 22, 0, 0, 0), "Evening Shift", new TimeSpan(0, 18, 0, 0, 0), new DateTime(2025, 3, 22, 14, 12, 20, 250, DateTimeKind.Local).AddTicks(3740) },
                    { new Guid("90719001-8195-457a-9315-bf978a25ac19"), new DateTime(2025, 3, 22, 14, 12, 20, 250, DateTimeKind.Local).AddTicks(3340), new TimeSpan(0, 12, 0, 0, 0), "Morning Shift", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 3, 22, 14, 12, 20, 250, DateTimeKind.Local).AddTicks(3340) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("0771b96d-4e7f-47d8-b440-695fe10389dc"));

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("6ee8ee0d-13f7-4d51-9a57-58dc4a77f625"));

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("90719001-8195-457a-9315-bf978a25ac19"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Admins");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 20, 23, 33, 47, 604, DateTimeKind.Local).AddTicks(5040), new DateTime(2025, 3, 20, 23, 33, 47, 604, DateTimeKind.Local).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "Auths",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 20, 23, 33, 47, 592, DateTimeKind.Local).AddTicks(6380), new DateTime(2025, 3, 20, 23, 33, 47, 603, DateTimeKind.Local).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "Auths",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 20, 23, 33, 47, 603, DateTimeKind.Local).AddTicks(5590), new DateTime(2025, 3, 20, 23, 33, 47, 603, DateTimeKind.Local).AddTicks(5590) });

            migrationBuilder.UpdateData(
                table: "Auths",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 20, 23, 33, 47, 603, DateTimeKind.Local).AddTicks(5600), new DateTime(2025, 3, 20, 23, 33, 47, 603, DateTimeKind.Local).AddTicks(5600) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 20, 23, 33, 47, 604, DateTimeKind.Local).AddTicks(4040), new DateTime(2025, 3, 20, 23, 33, 47, 604, DateTimeKind.Local).AddTicks(4040) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 20, 23, 33, 47, 604, DateTimeKind.Local).AddTicks(2600), new DateTime(2025, 3, 20, 23, 33, 47, 604, DateTimeKind.Local).AddTicks(2610) });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "CreatedAt", "EndTime", "Name", "StartTime", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("203945cd-7d82-48d9-8e23-54f810d4709d"), new DateTime(2025, 3, 20, 23, 33, 47, 604, DateTimeKind.Local).AddTicks(6510), new TimeSpan(0, 18, 0, 0, 0), "Afternoon Shift", new TimeSpan(0, 12, 0, 0, 0), new DateTime(2025, 3, 20, 23, 33, 47, 604, DateTimeKind.Local).AddTicks(6510) },
                    { new Guid("bc774cbb-a6a4-4612-b8c0-991b80d74f04"), new DateTime(2025, 3, 20, 23, 33, 47, 604, DateTimeKind.Local).AddTicks(6120), new TimeSpan(0, 12, 0, 0, 0), "Morning Shift", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 3, 20, 23, 33, 47, 604, DateTimeKind.Local).AddTicks(6120) },
                    { new Guid("d7d4295b-fdde-4b7e-8b61-98cde850c9e9"), new DateTime(2025, 3, 20, 23, 33, 47, 604, DateTimeKind.Local).AddTicks(6520), new TimeSpan(0, 22, 0, 0, 0), "Evening Shift", new TimeSpan(0, 18, 0, 0, 0), new DateTime(2025, 3, 20, 23, 33, 47, 604, DateTimeKind.Local).AddTicks(6520) }
                });
        }
    }
}
