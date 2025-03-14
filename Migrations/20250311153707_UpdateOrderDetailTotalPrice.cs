﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeHub.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderDetailTotalPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "OrderDetails",
                newName: "TotalPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "OrderDetails",
                newName: "Total");
        }
    }
}
