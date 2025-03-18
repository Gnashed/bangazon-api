using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class SeededAnotherOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EstimatedDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "EstimatedDeliveryDate", "IsCompleted", "OrderDate", "OrderStatus", "OrderTotal", "PaymentMethodId", "SellerId" },
                values: new object[] { 2, 1, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", 20.00m, 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EstimatedDeliveryDate", "OrderDate" },
                values: new object[] { new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 16, 23, 25, 37, 184, DateTimeKind.Local).AddTicks(5890) });
        }
    }
}
