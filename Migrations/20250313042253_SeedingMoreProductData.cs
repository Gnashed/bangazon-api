using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class SeedingMoreProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 12, 23, 22, 52, 832, DateTimeKind.Local).AddTicks(8270));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price", "QuantityAvailable", "SellerId", "StoreId" },
                values: new object[,]
                {
                    { 2, "Processors", "The AMD Ryzen 7 5800X is built on the Zen 3 architecture, offering 8 cores and 16 threads. With a base clock of 3.8 GHz and a max boost clock of 4.7 GHz, it's perfect for gaming, streaming, and content creation. The 5800X supports PCIe 4.0 and features an unlocked multiplier for overclocking enthusiasts.", "AMD Ryzen 7 5800X", 35000m, 15, null, 1 },
                    { 3, "Motherboards", "The ASUS ROG Strix B550-F Gaming motherboard is designed for AMD Ryzen processors and features PCIe 4.0 support, robust power delivery, and AI noise-canceling technology. It includes multiple M.2 slots, WiFi 6, and a high-performance VRM cooling solution for enhanced overclocking capabilities.", "ASUS ROG Strix B550-F Gaming", 18000m, 10, null, 1 },
                    { 4, "Memory", "Corsair Vengeance RGB Pro series DDR4 memory is designed for high-performance overclocking. It features dynamic multi-zone RGB lighting and is optimized for Intel and AMD platforms. The memory is built with a custom PCB and tightly screened memory chips to ensure excellent performance and stability.", "Corsair Vengeance RGB Pro 32GB (2 x 16GB) DDR4-3600", 15000m, 20, null, 1 },
                    { 5, "Storage", "The Samsung 970 EVO Plus 1TB NVMe SSD delivers top-tier performance with read speeds up to 3,500 MB/s and write speeds up to 3,300 MB/s. Powered by Samsung's V-NAND technology, it ensures reliability and durability for demanding workloads and gaming.", "Samsung 970 EVO Plus 1TB NVMe SSD", 12000m, 30, null, 1 },
                    { 6, "Power Supplies", "The Seasonic Focus GX-850 provides 850W of clean and stable power with 80 PLUS Gold efficiency. It's fully modular, ensuring easy cable management and reduced clutter. It features a 10-year warranty and premium hybrid fan control for silent operation.", "Seasonic Focus GX-850, 850W 80+ Gold", 14000m, 12, null, 1 },
                    { 7, "Cooling", "The Noctua NH-D15 Chromax.Black is a premium dual-tower CPU cooler known for its outstanding cooling performance and quiet operation. It features six heat pipes, two NF-A15 140mm fans, and a sleek all-black design.", "Noctua NH-D15 Chromax.Black", 10000m, 18, null, 1 },
                    { 8, "Cases", "The Lian Li PC-O11 Dynamic is a premium mid-tower case designed for performance and aesthetics. It features a tempered glass front and side panel, support for multiple radiators, and excellent cable management options.", "Lian Li PC-O11 Dynamic", 13000m, 22, null, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 10, 22, 59, 58, 322, DateTimeKind.Local).AddTicks(5700));
        }
    }
}
