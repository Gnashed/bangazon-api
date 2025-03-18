using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class AddedColumnItemQuantityToOrderItemsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemQuantity",
                table: "OrderItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                column: "ItemQuantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 3 },
                column: "ItemQuantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 5 },
                column: "ItemQuantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 7 },
                column: "ItemQuantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 9 },
                column: "ItemQuantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 10 },
                column: "ItemQuantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 11 },
                column: "ItemQuantity",
                value: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemQuantity",
                table: "OrderItems");
        }
    }
}
