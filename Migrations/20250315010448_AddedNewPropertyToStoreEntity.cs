using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewPropertyToStoreEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StoreImageUrl",
                table: "Stores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 14, 20, 4, 48, 286, DateTimeKind.Local).AddTicks(2650));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "StoreImageUrl",
                value: "https://www.intel.com/content/dam/www/central-libraries/us/en/images/2023-01/s9-u05-03-overhead-pc-components-original-rwd.jpg.rendition.intel.web.480.270.jpg");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                column: "StoreImageUrl",
                value: "https://jhrvt.com/uploads/gallery/658/Photos_Website_Banners(2).jpeg");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 3,
                column: "StoreImageUrl",
                value: "https://valorfitness.com/cdn/shop/files/valor-fitness-equipment-retail-store-pinellas_600x600@2x.jpg");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 4,
                column: "StoreImageUrl",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreImageUrl",
                table: "Stores");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 14, 18, 17, 54, 704, DateTimeKind.Local).AddTicks(4440));
        }
    }
}
