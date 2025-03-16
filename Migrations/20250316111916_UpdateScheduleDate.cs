using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeHub.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScheduleDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_Employees_EmployeeId",
                table: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_EmployeeId",
                table: "Shifts");

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

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Shifts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Schedules",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Shifts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "Schedules",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_EmployeeId",
                table: "Shifts",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Employees_EmployeeId",
                table: "Shifts",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
