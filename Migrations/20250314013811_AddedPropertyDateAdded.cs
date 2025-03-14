using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class AddedPropertyDateAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "imageUrl",
                table: "Products",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Products",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 13, 20, 38, 11, 160, DateTimeKind.Local).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAdded", "Description" },
                values: new object[] { new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The EVGA GeForce RTX 3060 12GB provides players with the ability to vanquish 1080p and 1440p gaming..." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAdded", "Description" },
                values: new object[] { new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The AMD Ryzen 7 5800X is built on the Zen 3 architecture, offering 8 cores and 16 threads..." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateAdded", "Description" },
                values: new object[] { new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The ASUS ROG Strix B550-F Gaming motherboard is designed for AMD Ryzen processors..." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateAdded", "Description", "Name" },
                values: new object[] { new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corsair Vengeance RGB Pro series DDR4 memory is designed for high-performance overclocking...", "Corsair Vengeance RGB Pro 32GB" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "DateAdded", "Description", "ImageUrl", "Name", "Price", "QuantityAvailable", "SellerId", "StoreId" },
                values: new object[,]
                {
                    { 9, "Basketball Products", new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Official size and weight, indoor/outdoor use.", "spalding_nba_ball.jpg", "Spalding NBA Basketball", 2999m, 15, null, 2 },
                    { 10, "Basketball Products", new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lightweight and breathable, with Dri-FIT technology.", "nike_elite_shorts.jpg", "Nike Elite Basketball Shorts", 4500m, 30, null, 2 },
                    { 11, "Basketball Products", new DateTime(2025, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "High-quality composite leather, soft feel and grip.", "wilson_evolution.jpg", "Wilson Evolution Basketball", 6499m, 20, null, 2 },
                    { 12, "Basketball Products", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iconic design with superior traction and support.", "jordan_jumpman_shoes.jpg", "Jordan Jumpman Basketball Shoes", 12000m, 10, null, 2 },
                    { 13, "Basketball Products", new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compression sleeve for improved circulation and performance.", "adidas_shooting_sleeve.jpg", "Adidas Shooting Sleeve", 1899m, 25, null, 2 },
                    { 14, "Basketball Products", new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moisture-wicking and cushioned for comfort.", "ua_basketball_socks.jpg", "Under Armour Basketball Socks", 1499m, 40, null, 2 },
                    { 15, "Basketball Products", new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adjustable height, weather-resistant material.", "basketball_hoop.jpg", "Basketball Hoop with Stand", 19999m, 5, null, 2 },
                    { 16, "Basketball Products", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Used in official FIBA games, premium feel.", "molten_game_ball.jpg", "Molten Official Game Ball", 8999m, 12, null, 2 },
                    { 17, "Fitness Equipment", new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pair of adjustable dumbbells with weight range from 5 to 52.5 lbs.", "bowflex_selecttech.jpg", "Bowflex SelectTech 552 Adjustable Dumbbells", 34999m, 10, null, 3 },
                    { 18, "Fitness Equipment", new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "High-end stationary bike with live and on-demand classes.", "peloton_bike.jpg", "Peloton Bike+", 249500m, 5, null, 3 },
                    { 19, "Fitness Equipment", new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Portable, full-body workout system using suspension straps.", "trx_trainer.jpg", "TRX Suspension Trainer", 19999m, 15, null, 3 },
                    { 20, "Fitness Equipment", new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "High-end treadmill with incline and interactive training.", "nordictrack_treadmill.jpg", "NordicTrack Commercial 1750 Treadmill", 229999m, 8, null, 3 },
                    { 21, "Fitness Equipment", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deep tissue muscle treatment with customizable speed settings.", "theragun_elite.jpg", "Theragun Elite Percussion Massager", 39999m, 12, null, 3 },
                    { 22, "Fitness Equipment", new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Advanced fitness tracker with heart rate monitoring and GPS.", "fitbit_charge6.jpg", "Fitbit Charge 6", 14999m, 20, null, 3 },
                    { 23, "Fitness Equipment", new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heavy-duty air bike with reinforced steel construction.", "rogue_echo_bike.jpg", "Rogue Echo Bike", 79500m, 7, null, 3 },
                    { 24, "Fitness Equipment", new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lightweight percussion massage gun for muscle recovery.", "hypervolt_go2.jpg", "Hyperice Hypervolt Go 2", 12999m, 18, null, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "imageUrl");

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
                column: "Description",
                value: "The EVGA GeForce RTX 3060 12GB provides players with the ability to vanquish 1080p and 1440p gaming, while providing a quality NVIDIA RTX experience and a myriad of productivity benefits. The card is powered by NVIDIA Ampere architecture, which doubles down on ray tracing and AI performance with enhanced RT cores, Tensor Cores, and new streaming multiprocessors. With 12GB of GDDR6 memory, high-end performance does not have to be sacrificed to find a card for gaming and everyday use.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "The AMD Ryzen 7 5800X is built on the Zen 3 architecture, offering 8 cores and 16 threads. With a base clock of 3.8 GHz and a max boost clock of 4.7 GHz, it's perfect for gaming, streaming, and content creation. The 5800X supports PCIe 4.0 and features an unlocked multiplier for overclocking enthusiasts.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "The ASUS ROG Strix B550-F Gaming motherboard is designed for AMD Ryzen processors and features PCIe 4.0 support, robust power delivery, and AI noise-canceling technology. It includes multiple M.2 slots, WiFi 6, and a high-performance VRM cooling solution for enhanced overclocking capabilities.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Corsair Vengeance RGB Pro series DDR4 memory is designed for high-performance overclocking. It features dynamic multi-zone RGB lighting and is optimized for Intel and AMD platforms. The memory is built with a custom PCB and tightly screened memory chips to ensure excellent performance and stability.", "Corsair Vengeance RGB Pro 32GB (2 x 16GB) DDR4-3600" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price", "QuantityAvailable", "SellerId", "StoreId", "imageUrl" },
                values: new object[,]
                {
                    { 5, "Storage", "The Samsung 970 EVO Plus 1TB NVMe SSD delivers top-tier performance with read speeds up to 3,500 MB/s and write speeds up to 3,300 MB/s. Powered by Samsung's V-NAND technology, it ensures reliability and durability for demanding workloads and gaming.", "Samsung 970 EVO Plus 1TB NVMe SSD", 12000m, 30, null, 1, "https://media.gamestop.com/i/gamestop/11165893_ALT03/Samsung-970-EVO-Plus-1TB-PCIe-3.0-NVMe-M.2-Internal-V-NAND-Solid-State-Drive?fmt=auto" },
                    { 6, "Power Supplies", "The Seasonic Focus GX-850 provides 850W of clean and stable power with 80 PLUS Gold efficiency. It's fully modular, ensuring easy cable management and reduced clutter. It features a 10-year warranty and premium hybrid fan control for silent operation.", "Seasonic Focus GX-850, 850W 80+ Gold", 14000m, 12, null, 1, "https://www.cybertek.fr/images_produits/6674c605-41e1-4aa3-b679-3b1b7446a850.jpg" },
                    { 7, "Cooling", "The Noctua NH-D15 Chromax.Black is a premium dual-tower CPU cooler known for its outstanding cooling performance and quiet operation. It features six heat pipes, two NF-A15 140mm fans, and a sleek all-black design.", "Noctua NH-D15 Chromax.Black", 10000m, 18, null, 1, "https://d.scdn.gr/images/sku_images/037632/37632247/20210121164405_b9029b13.jpeg" },
                    { 8, "Cases", "The Lian Li PC-O11 Dynamic is a premium mid-tower case designed for performance and aesthetics. It features a tempered glass front and side panel, support for multiple radiators, and excellent cable management options.", "Lian Li PC-O11 Dynamic", 13000m, 22, null, 1, "https://www.profesionalreview.com/wp-content/uploads/2018/04/Lian-Li-PC-O11-Dynamic-un-chasis-con-mucho-cristal-1.jpg" }
                });
        }
    }
}
