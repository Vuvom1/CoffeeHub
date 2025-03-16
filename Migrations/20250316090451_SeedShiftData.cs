using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeHub.Migrations
{
    /// <inheritdoc />
    public partial class SeedShiftData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 16, 16, 4, 51, 189, DateTimeKind.Local).AddTicks(1780), new DateTime(2025, 3, 16, 16, 4, 51, 189, DateTimeKind.Local).AddTicks(1790) });

            migrationBuilder.UpdateData(
                table: "Auths",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 16, 16, 4, 51, 189, DateTimeKind.Local).AddTicks(2810), new DateTime(2025, 3, 16, 16, 4, 51, 189, DateTimeKind.Local).AddTicks(2810) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 16, 16, 4, 51, 189, DateTimeKind.Local).AddTicks(860), new DateTime(2025, 3, 16, 16, 4, 51, 189, DateTimeKind.Local).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 16, 16, 4, 51, 178, DateTimeKind.Local).AddTicks(1050), new DateTime(2025, 3, 16, 16, 4, 51, 188, DateTimeKind.Local).AddTicks(6090) });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "CreatedAt", "EmployeeId", "EndTime", "Name", "StartTime", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("8ed2c9b3-60e3-4e36-a15d-5df987296de2"), new DateTime(2025, 3, 16, 16, 4, 51, 189, DateTimeKind.Local).AddTicks(4410), null, new TimeSpan(0, 22, 0, 0, 0), "Evening Shift", new TimeSpan(0, 18, 0, 0, 0), new DateTime(2025, 3, 16, 16, 4, 51, 189, DateTimeKind.Local).AddTicks(4410) },
                    { new Guid("dbb63771-edc4-4d57-820f-c5b471bafe0c"), new DateTime(2025, 3, 16, 16, 4, 51, 189, DateTimeKind.Local).AddTicks(4020), null, new TimeSpan(0, 12, 0, 0, 0), "Morning Shift", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 3, 16, 16, 4, 51, 189, DateTimeKind.Local).AddTicks(4020) },
                    { new Guid("dfb0a83b-b626-4234-a084-894a3c4b1140"), new DateTime(2025, 3, 16, 16, 4, 51, 189, DateTimeKind.Local).AddTicks(4400), null, new TimeSpan(0, 18, 0, 0, 0), "Afternoon Shift", new TimeSpan(0, 12, 0, 0, 0), new DateTime(2025, 3, 16, 16, 4, 51, 189, DateTimeKind.Local).AddTicks(4400) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("8ed2c9b3-60e3-4e36-a15d-5df987296de2"));

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("dbb63771-edc4-4d57-820f-c5b471bafe0c"));

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("dfb0a83b-b626-4234-a084-894a3c4b1140"));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 16, 1, 28, 58, 448, DateTimeKind.Local).AddTicks(8180), new DateTime(2025, 3, 16, 1, 28, 58, 448, DateTimeKind.Local).AddTicks(8190) });

            migrationBuilder.UpdateData(
                table: "Auths",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 16, 1, 28, 58, 448, DateTimeKind.Local).AddTicks(9280), new DateTime(2025, 3, 16, 1, 28, 58, 448, DateTimeKind.Local).AddTicks(9290) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 16, 1, 28, 58, 448, DateTimeKind.Local).AddTicks(7250), new DateTime(2025, 3, 16, 1, 28, 58, 448, DateTimeKind.Local).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 16, 1, 28, 58, 437, DateTimeKind.Local).AddTicks(3670), new DateTime(2025, 3, 16, 1, 28, 58, 448, DateTimeKind.Local).AddTicks(2170) });
        }
    }
}
