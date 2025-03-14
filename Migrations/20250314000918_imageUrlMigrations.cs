using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class imageUrlMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 13, 19, 9, 17, 876, DateTimeKind.Local).AddTicks(4080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "imageUrl",
                value: "https://i.pinimg.com/originals/8c/4a/a4/8c4aa4434669caabab3ef0e0fea4958d.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "imageUrl",
                value: "https://www.techinn.com/f/13795/137954422/amd-ryzen-7-5800x-3.8ghz.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "imageUrl",
                value: "https://images.anandtech.com/doci/15868/ROG-STRIX-B550-F-GAMING-WI-FI-What_s-inside-the-Box.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "imageUrl",
                value: "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6449/6449223_sd.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "imageUrl",
                value: "https://media.gamestop.com/i/gamestop/11165893_ALT03/Samsung-970-EVO-Plus-1TB-PCIe-3.0-NVMe-M.2-Internal-V-NAND-Solid-State-Drive?fmt=auto");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "imageUrl",
                value: "https://www.cybertek.fr/images_produits/6674c605-41e1-4aa3-b679-3b1b7446a850.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "imageUrl",
                value: "https://d.scdn.gr/images/sku_images/037632/37632247/20210121164405_b9029b13.jpeg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "imageUrl",
                value: "https://www.profesionalreview.com/wp-content/uploads/2018/04/Lian-Li-PC-O11-Dynamic-un-chasis-con-mucho-cristal-1.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 12, 23, 22, 52, 832, DateTimeKind.Local).AddTicks(8270));
        }
    }
}
