using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class SeededAnotherOrderV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderId", "ProductId" },
                values: new object[,]
                {
                    { 2, 9 },
                    { 2, 10 },
                    { 2, 11 }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderTotal",
                value: 2000.00m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderTotal",
                value: 20.00m);
        }
    }
}
