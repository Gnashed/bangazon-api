using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUrlsInProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 14, 18, 0, 53, 436, DateTimeKind.Local).AddTicks(2840));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://cdn4.volusion.store/phzup-xttqn/v/vspfiles/photos/63-306E-2.jpg?v-cache=1640967916", "Spalding NBA Varsity Basketball (outdoor)" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://i.ebayimg.com/images/g/YlgAAOSw~WpgqyDw/s-l1200.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://i5.walmartimages.com/asr/b624338a-fe3a-4036-92c7-3e5dfc3d41e1_1.660a529a42734dc1008fc53ada274653.jpeg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Category", "ImageUrl", "Name" },
                values: new object[] { "Basketball Shoes", "https://i.ebayimg.com/00/s/MTI3NlgxMjgw/z/uCMAAOSw0x1k5cIg/$_57.JPG?set_id=8800005007", "Air Jordan 13 Retro Basketball Shoes (RED/WHITE)" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://i.ebayimg.com/images/g/SRIAAOSwRwFfWx36/s-l1200.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://www.kicksown.com/cdn/shop/files/20240821172318.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/I/61CKDFncGbL._AC_UF1000,1000_QL80_.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://shop.moltensports.jp/cdn/shop/articles/20210902_01_01.png?v=1644331911");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://www.bowflex.com/dw/image/v2/AAYW_PRD/on/demandware.static/-/Sites-nautilus-master-catalog/default/dwf21fb1cf/images/bfx/weights/100131/bowflex-selecttech-552-dumbbell-weights-hero.jpg?sw=2600&sh=1464&sm=fit");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://res.cloudinary.com/peloton-cycle/image/fetch/dpr_2.0,f_auto,q_auto:good,w_768/https://images.ctfassets.net/7vk8puwnesgc/570NDQUa4nJVo466mxbUuv/f55258ef9420c35a68da5d5f22146184/20_5632_PELOTON_BIKE_RENDERS_TITAN-ALT_M_BOTH_W1_F_LAYERED_NO_WEIGHTS.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://www.trxtraining.com/cdn/shop/products/21_09_03_Lifestyle_Yoga9924_1_1800x.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "https://images.squarespace-cdn.com/content/v1/5d910d397c5f112386050a97/1683788362652-OHHR47KPE93R120TDBGJ/4639edfc-62e4-43d9-ba0b-42993121c7a8.png?");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/I/61HwDKWhdML.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/I/61wn2jfhBkL.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImageUrl",
                value: "https://i0.wp.com/asmanyreviewsaspossible.com/wp-content/uploads/2017/12/echo-bike-slider-5-new.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImageUrl",
                value: "https://mygalf.com/uploads/product_image/1669367949Hypervolt2_MainPic.jpeg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 13, 21, 57, 11, 520, DateTimeKind.Local).AddTicks(520));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "spalding_nba_ball.jpg", "Spalding NBA Basketball" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "nike_elite_shorts.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "wilson_evolution.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Category", "ImageUrl", "Name" },
                values: new object[] { "Basketball Products", "jordan_jumpman_shoes.jpg", "Jordan Jumpman Basketball Shoes" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "adidas_shooting_sleeve.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "ua_basketball_socks.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "basketball_hoop.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "molten_game_ball.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "bowflex_selecttech.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "peloton_bike.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "trx_trainer.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "nordictrack_treadmill.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "theragun_elite.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "fitbit_charge6.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImageUrl",
                value: "rogue_echo_bike.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImageUrl",
                value: "hypervolt_go2.jpg");
        }
    }
}
