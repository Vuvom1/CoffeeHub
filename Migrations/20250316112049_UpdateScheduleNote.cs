using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeHub.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScheduleNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("00bd7c11-281c-4d8f-936e-e34bda82fb97"));

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("ad00c237-bf48-4772-977e-170b878902e7"));

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: new Guid("ba27fa41-d2fd-40c6-a3b4-90fc9111bb5e"));

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 16, 18, 19, 15, 481, DateTimeKind.Local).AddTicks(710), new DateTime(2025, 3, 16, 18, 19, 15, 481, DateTimeKind.Local).AddTicks(710) });

            migrationBuilder.UpdateData(
                table: "Auths",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 16, 18, 19, 15, 481, DateTimeKind.Local).AddTicks(1770), new DateTime(2025, 3, 16, 18, 19, 15, 481, DateTimeKind.Local).AddTicks(1770) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 16, 18, 19, 15, 480, DateTimeKind.Local).AddTicks(9740), new DateTime(2025, 3, 16, 18, 19, 15, 480, DateTimeKind.Local).AddTicks(9740) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 16, 18, 19, 15, 469, DateTimeKind.Local).AddTicks(7040), new DateTime(2025, 3, 16, 18, 19, 15, 480, DateTimeKind.Local).AddTicks(4920) });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "CreatedAt", "EndTime", "Name", "StartTime", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00bd7c11-281c-4d8f-936e-e34bda82fb97"), new DateTime(2025, 3, 16, 18, 19, 15, 481, DateTimeKind.Local).AddTicks(3090), new TimeSpan(0, 12, 0, 0, 0), "Morning Shift", new TimeSpan(0, 6, 0, 0, 0), new DateTime(2025, 3, 16, 18, 19, 15, 481, DateTimeKind.Local).AddTicks(3090) },
                    { new Guid("ad00c237-bf48-4772-977e-170b878902e7"), new DateTime(2025, 3, 16, 18, 19, 15, 481, DateTimeKind.Local).AddTicks(3520), new TimeSpan(0, 22, 0, 0, 0), "Evening Shift", new TimeSpan(0, 18, 0, 0, 0), new DateTime(2025, 3, 16, 18, 19, 15, 481, DateTimeKind.Local).AddTicks(3520) },
                    { new Guid("ba27fa41-d2fd-40c6-a3b4-90fc9111bb5e"), new DateTime(2025, 3, 16, 18, 19, 15, 481, DateTimeKind.Local).AddTicks(3510), new TimeSpan(0, 18, 0, 0, 0), "Afternoon Shift", new TimeSpan(0, 12, 0, 0, 0), new DateTime(2025, 3, 16, 18, 19, 15, 481, DateTimeKind.Local).AddTicks(3510) }
                });
        }
    }
}
