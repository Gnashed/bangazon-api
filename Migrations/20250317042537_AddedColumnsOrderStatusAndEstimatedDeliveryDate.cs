using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class AddedColumnsOrderStatusAndEstimatedDeliveryDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EstimatedDeliveryDate",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OrderStatus",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EstimatedDeliveryDate", "OrderDate", "OrderStatus" },
                values: new object[] { new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 16, 23, 25, 37, 184, DateTimeKind.Local).AddTicks(5890), "Shipped" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedDeliveryDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 16, 19, 49, 50, 893, DateTimeKind.Local).AddTicks(6560));
        }
    }
}
