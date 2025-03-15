using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedStoreImageUrlInStoreTableV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 14, 20, 33, 5, 990, DateTimeKind.Local).AddTicks(520));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "StoreImageUrl",
                value: "intel.com/content/dam/www/central-libraries/us/en/images/2023-01/s9-u05-03-overhead-pc-components-original-rwd.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
