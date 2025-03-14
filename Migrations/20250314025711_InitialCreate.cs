using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsSeller = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StoreId = table.Column<int>(type: "integer", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sellers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    SellerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SellerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardNumber = table.Column<string>(type: "text", nullable: false),
                    SecurityCode = table.Column<int>(type: "integer", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethods_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "integer", nullable: false),
                    StoreId = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SellerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    OrderTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "integer", nullable: false),
                    SellerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsSeller", "Uid" },
                values: new object[,]
                {
                    { 1, false, "zmwuMjpI5RXABj6mImfK2O586Qf1" },
                    { 2, false, "eBBiuMs6zCYuRFk5657mXQBemjh1" },
                    { 3, true, "change-me-2" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "FirstName", "LastName", "SellerId", "State", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { 1, "1234 Apple Rd.", "Nashville", "Tion", "Blackmon", null, "TN", 1, 37000 },
                    { 2, "HQ", "Nashville", "Admin", "(SWE)", null, "TN", 2, 37000 }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "StoreId", "UserId", "Username" },
                values: new object[,]
                {
                    { 1, 1, 2, "TionB" },
                    { 2, 1, 1, "Rob90" },
                    { 3, 1, 3, "BeachVibes98" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "CardNumber", "CustomerId", "ExpirationDate", "SecurityCode" },
                values: new object[] { 1, "4444-4444-4444-4444", 1, new DateTime(2028, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 778 });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Name", "SellerId" },
                values: new object[,]
                {
                    { 1, "PC Parts", 1 },
                    { 2, "Sports Products", 1 },
                    { 3, "Fitness Equipment", 1 },
                    { 4, "Update me", 3 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "IsCompleted", "OrderDate", "OrderTotal", "PaymentMethodId", "SellerId" },
                values: new object[] { 1, 1, true, new DateTime(2025, 3, 13, 21, 57, 11, 520, DateTimeKind.Local).AddTicks(520), 25000m, 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "DateAdded", "Description", "ImageUrl", "Name", "Price", "QuantityAvailable", "SellerId", "StoreId" },
                values: new object[,]
                {
                    { 1, "Graphics Cards", new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The EVGA GeForce RTX 3060 12GB provides players with the ability to vanquish 1080p and 1440p gaming...", "https://i.pinimg.com/originals/8c/4a/a4/8c4aa4434669caabab3ef0e0fea4958d.jpg", "EVGA GeForce RTX 3060 XC 12GB", 25000m, 25, null, 1 },
                    { 2, "Processors", new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The AMD Ryzen 7 5800X is built on the Zen 3 architecture, offering 8 cores and 16 threads...", "https://www.techinn.com/f/13795/137954422/amd-ryzen-7-5800x-3.8ghz.jpg", "AMD Ryzen 7 5800X", 35000m, 15, null, 1 },
                    { 3, "Motherboards", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The ASUS ROG Strix B550-F Gaming motherboard is designed for AMD Ryzen processors...", "https://images.anandtech.com/doci/15868/ROG-STRIX-B550-F-GAMING-WI-FI-What_s-inside-the-Box.jpg", "ASUS ROG Strix B550-F Gaming", 18000m, 10, null, 1 },
                    { 4, "Memory", new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corsair Vengeance RGB Pro series DDR4 memory is designed for high-performance overclocking...", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6449/6449223_sd.jpg", "Corsair Vengeance RGB Pro 32GB", 15000m, 20, null, 1 },
                    { 5, "Basketball Products", new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Official size and weight, indoor/outdoor use.", "spalding_nba_ball.jpg", "Spalding NBA Basketball", 2999m, 15, null, 2 },
                    { 6, "Basketball Products", new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lightweight and breathable, with Dri-FIT technology.", "nike_elite_shorts.jpg", "Nike Elite Basketball Shorts", 4500m, 30, null, 2 },
                    { 7, "Basketball Products", new DateTime(2025, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "High-quality composite leather, soft feel and grip.", "wilson_evolution.jpg", "Wilson Evolution Basketball", 6499m, 20, null, 2 },
                    { 8, "Basketball Products", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iconic design with superior traction and support.", "jordan_jumpman_shoes.jpg", "Jordan Jumpman Basketball Shoes", 12000m, 10, null, 2 },
                    { 9, "Basketball Products", new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compression sleeve for improved circulation and performance.", "adidas_shooting_sleeve.jpg", "Adidas Shooting Sleeve", 1899m, 25, null, 2 },
                    { 10, "Basketball Products", new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moisture-wicking and cushioned for comfort.", "ua_basketball_socks.jpg", "Under Armour Basketball Socks", 1499m, 40, null, 2 },
                    { 11, "Basketball Products", new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adjustable height, weather-resistant material.", "basketball_hoop.jpg", "Basketball Hoop with Stand", 19999m, 5, null, 2 },
                    { 12, "Basketball Products", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Used in official FIBA games, premium feel.", "molten_game_ball.jpg", "Molten Official Game Ball", 8999m, 12, null, 2 },
                    { 13, "Fitness Equipment", new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pair of adjustable dumbbells with weight range from 5 to 52.5 lbs.", "bowflex_selecttech.jpg", "Bowflex SelectTech 552 Adjustable Dumbbells", 34999m, 10, null, 3 },
                    { 14, "Fitness Equipment", new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "High-end stationary bike with live and on-demand classes.", "peloton_bike.jpg", "Peloton Bike+", 249500m, 5, null, 3 },
                    { 15, "Fitness Equipment", new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Portable, full-body workout system using suspension straps.", "trx_trainer.jpg", "TRX Suspension Trainer", 19999m, 15, null, 3 },
                    { 16, "Fitness Equipment", new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "High-end treadmill with incline and interactive training.", "nordictrack_treadmill.jpg", "NordicTrack Commercial 1750 Treadmill", 229999m, 8, null, 3 },
                    { 17, "Fitness Equipment", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deep tissue muscle treatment with customizable speed settings.", "theragun_elite.jpg", "Theragun Elite Percussion Massager", 39999m, 12, null, 3 },
                    { 18, "Fitness Equipment", new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Advanced fitness tracker with heart rate monitoring and GPS.", "fitbit_charge6.jpg", "Fitbit Charge 6", 14999m, 20, null, 3 },
                    { 19, "Fitness Equipment", new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heavy-duty air bike with reinforced steel construction.", "rogue_echo_bike.jpg", "Rogue Echo Bike", 79500m, 7, null, 3 },
                    { 20, "Fitness Equipment", new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lightweight percussion massage gun for muscle recovery.", "hypervolt_go2.jpg", "Hyperice Hypervolt Go 2", 12999m, 18, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SellerId",
                table: "Customers",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SellerId",
                table: "Orders",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_CustomerId",
                table: "PaymentMethods",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerId",
                table: "Products",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId",
                table: "Products",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_UserId",
                table: "Sellers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_SellerId",
                table: "Stores",
                column: "SellerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
