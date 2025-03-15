using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedStoreImageUrlInStoreTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 14, 20, 31, 22, 479, DateTimeKind.Local).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "StoreImageUrl",
                value: "www.intel.com/content/dam/www/central-libraries/us/en/images/2023-01/s9-u05-03-overhead-pc-components-original-rwd.jpg.rendition.intel.web.480.270.jpg");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                column: "StoreImageUrl",
                value: "jhrvt.com/uploads/gallery/658/Photos_Website_Banners(2).jpeg");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 3,
                column: "StoreImageUrl",
                value: "valorfitness.com/cdn/shop/files/valor-fitness-equipment-retail-store-pinellas_600x600@2x.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
