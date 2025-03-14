using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewProductInProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 14, 18, 15, 36, 226, DateTimeKind.Local).AddTicks(8560));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "DateAdded", "Description", "ImageUrl", "Name", "Price", "QuantityAvailable", "SellerId", "StoreId" },
                values: new object[] { 21, "Fitness Equipment", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Multi-function bodyweight trainer designed for push-ups, pull-ups, dips, squats, and more.", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.bowflex.com%2Fon%2Fdemandware.static%2F-%2FSites-nautilus-master-catalog%2Fdefault%2Fdwef1d0694%2Fimages%2Fbowflex%2Fhome-gyms%2Fbodytower%2Fbowflex-body-tower-home-gym-100243.png&f=1&nofb=1&ipt=f425033fd1393ed3a30be0fb314a557a5ab26041e395a47222128ad035a03fca&ipo=images", "Bowflex BodyTower", 399.99m, 9, null, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 14, 18, 0, 53, 436, DateTimeKind.Local).AddTicks(2840));
        }
    }
}
