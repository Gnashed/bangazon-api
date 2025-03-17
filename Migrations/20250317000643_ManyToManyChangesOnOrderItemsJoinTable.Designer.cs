﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bangazon.Migrations
{
    [DbContext(typeof(BangazonDbContext))]
    [Migration("20250317000643_ManyToManyChangesOnOrderItemsJoinTable")]
    partial class ManyToManyChangesOnOrderItemsJoinTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bangazon.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("SellerId")
                        .HasColumnType("integer");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("ZipCode")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.HasIndex("UserId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "1234 Apple Rd.",
                            City = "Nashville",
                            FirstName = "Tion",
                            LastName = "Blackmon",
                            State = "TN",
                            Uid = "eBBiuMs6zCYuRFk5657mXQBemjh1",
                            UserId = 1,
                            ZipCode = 37000
                        },
                        new
                        {
                            Id = 2,
                            Address = "HQ",
                            City = "Nashville",
                            FirstName = "Admin",
                            LastName = "(SWE)",
                            State = "TN",
                            Uid = "zmwuMjpI5RXABj6mImfK2O586Qf1",
                            UserId = 2,
                            ZipCode = 37000
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("numeric");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("integer");

                    b.Property<int?>("SellerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("SellerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            IsCompleted = true,
                            OrderDate = new DateTime(2025, 3, 16, 19, 6, 43, 164, DateTimeKind.Local).AddTicks(3590),
                            OrderTotal = 250.00m,
                            PaymentMethodId = 1
                        });
                });

            modelBuilder.Entity("Bangazon.Models.OrderItems", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            ProductId = 1
                        });
                });

            modelBuilder.Entity("Bangazon.Models.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("SecurityCode")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("PaymentMethods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CardNumber = "4444-4444-4444-4444",
                            CustomerId = 1,
                            ExpirationDate = new DateTime(2028, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SecurityCode = 778
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("QuantityAvailable")
                        .HasColumnType("integer");

                    b.Property<int?>("SellerId")
                        .HasColumnType("integer");

                    b.Property<int>("StoreId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.HasIndex("StoreId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Graphics Cards",
                            DateAdded = new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The EVGA GeForce RTX 3060 12GB provides players with the ability to vanquish 1080p and 1440p gaming...",
                            ImageUrl = "https://i.pinimg.com/originals/8c/4a/a4/8c4aa4434669caabab3ef0e0fea4958d.jpg",
                            Name = "EVGA GeForce RTX 3060 XC 12GB",
                            Price = 250.00m,
                            QuantityAvailable = 25,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 2,
                            Category = "Processors",
                            DateAdded = new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The AMD Ryzen 7 5800X is built on the Zen 3 architecture, offering 8 cores and 16 threads...",
                            ImageUrl = "https://www.techinn.com/f/13795/137954422/amd-ryzen-7-5800x-3.8ghz.jpg",
                            Name = "AMD Ryzen 7 5800X",
                            Price = 350.00m,
                            QuantityAvailable = 15,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 3,
                            Category = "Motherboards",
                            DateAdded = new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The ASUS ROG Strix B550-F Gaming motherboard is designed for AMD Ryzen processors...",
                            ImageUrl = "https://images.anandtech.com/doci/15868/ROG-STRIX-B550-F-GAMING-WI-FI-What_s-inside-the-Box.jpg",
                            Name = "ASUS ROG Strix B550-F Gaming",
                            Price = 180.00m,
                            QuantityAvailable = 10,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 4,
                            Category = "Memory",
                            DateAdded = new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Corsair Vengeance RGB Pro series DDR4 memory is designed for high-performance overclocking...",
                            ImageUrl = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6449/6449223_sd.jpg",
                            Name = "Corsair Vengeance RGB Pro 32GB",
                            Price = 150.00m,
                            QuantityAvailable = 20,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 5,
                            Category = "Basketball Products",
                            DateAdded = new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Official size and weight, indoor/outdoor use.",
                            ImageUrl = "https://cdn4.volusion.store/phzup-xttqn/v/vspfiles/photos/63-306E-2.jpg?v-cache=1640967916",
                            Name = "Spalding NBA Varsity Basketball (outdoor)",
                            Price = 29.99m,
                            QuantityAvailable = 15,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 6,
                            Category = "Basketball Products",
                            DateAdded = new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lightweight and breathable, with Dri-FIT technology.",
                            ImageUrl = "https://i.ebayimg.com/images/g/YlgAAOSw~WpgqyDw/s-l1200.jpg",
                            Name = "Nike Elite Basketball Shorts",
                            Price = 45.00m,
                            QuantityAvailable = 30,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 7,
                            Category = "Basketball Products",
                            DateAdded = new DateTime(2025, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "High-quality composite leather, soft feel and grip.",
                            ImageUrl = "https://i5.walmartimages.com/asr/b624338a-fe3a-4036-92c7-3e5dfc3d41e1_1.660a529a42734dc1008fc53ada274653.jpeg",
                            Name = "Wilson Evolution Basketball",
                            Price = 64.99m,
                            QuantityAvailable = 20,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 8,
                            Category = "Basketball Shoes",
                            DateAdded = new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Iconic design with superior traction and support.",
                            ImageUrl = "https://i.ebayimg.com/00/s/MTI3NlgxMjgw/z/uCMAAOSw0x1k5cIg/$_57.JPG?set_id=8800005007",
                            Name = "Air Jordan 13 Retro Basketball Shoes (RED/WHITE)",
                            Price = 120.00m,
                            QuantityAvailable = 10,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 9,
                            Category = "Basketball Products",
                            DateAdded = new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Compression sleeve for improved circulation and performance.",
                            ImageUrl = "https://i.ebayimg.com/images/g/SRIAAOSwRwFfWx36/s-l1200.jpg",
                            Name = "Adidas Shooting Sleeve",
                            Price = 18.99m,
                            QuantityAvailable = 25,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 10,
                            Category = "Basketball Products",
                            DateAdded = new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Moisture-wicking and cushioned for comfort.",
                            ImageUrl = "https://www.kicksown.com/cdn/shop/files/20240821172318.jpg",
                            Name = "Under Armour Basketball Socks",
                            Price = 14.99m,
                            QuantityAvailable = 40,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 11,
                            Category = "Basketball Products",
                            DateAdded = new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Adjustable height, weather-resistant material.",
                            ImageUrl = "https://m.media-amazon.com/images/I/61CKDFncGbL._AC_UF1000,1000_QL80_.jpg",
                            Name = "Basketball Hoop with Stand",
                            Price = 199.99m,
                            QuantityAvailable = 5,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 12,
                            Category = "Basketball Products",
                            DateAdded = new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Used in official FIBA games, premium feel.",
                            ImageUrl = "https://shop.moltensports.jp/cdn/shop/articles/20210902_01_01.png?v=1644331911",
                            Name = "Molten Official Game Ball",
                            Price = 89.99m,
                            QuantityAvailable = 12,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 13,
                            Category = "Fitness Equipment",
                            DateAdded = new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Pair of adjustable dumbbells with weight range from 5 to 52.5 lbs.",
                            ImageUrl = "https://www.bowflex.com/dw/image/v2/AAYW_PRD/on/demandware.static/-/Sites-nautilus-master-catalog/default/dwf21fb1cf/images/bfx/weights/100131/bowflex-selecttech-552-dumbbell-weights-hero.jpg?sw=2600&sh=1464&sm=fit",
                            Name = "Bowflex SelectTech 552 Adjustable Dumbbells",
                            Price = 349.99m,
                            QuantityAvailable = 10,
                            StoreId = 3
                        },
                        new
                        {
                            Id = 14,
                            Category = "Fitness Equipment",
                            DateAdded = new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "High-end stationary bike with live and on-demand classes.",
                            ImageUrl = "https://res.cloudinary.com/peloton-cycle/image/fetch/dpr_2.0,f_auto,q_auto:good,w_768/https://images.ctfassets.net/7vk8puwnesgc/570NDQUa4nJVo466mxbUuv/f55258ef9420c35a68da5d5f22146184/20_5632_PELOTON_BIKE_RENDERS_TITAN-ALT_M_BOTH_W1_F_LAYERED_NO_WEIGHTS.jpg",
                            Name = "Peloton Bike+",
                            Price = 2495.00m,
                            QuantityAvailable = 5,
                            StoreId = 3
                        },
                        new
                        {
                            Id = 15,
                            Category = "Fitness Equipment",
                            DateAdded = new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Portable, full-body workout system using suspension straps.",
                            ImageUrl = "https://www.trxtraining.com/cdn/shop/products/21_09_03_Lifestyle_Yoga9924_1_1800x.jpg",
                            Name = "TRX Suspension Trainer",
                            Price = 199.99m,
                            QuantityAvailable = 15,
                            StoreId = 3
                        },
                        new
                        {
                            Id = 16,
                            Category = "Fitness Equipment",
                            DateAdded = new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "High-end treadmill with incline and interactive training.",
                            ImageUrl = "https://images.squarespace-cdn.com/content/v1/5d910d397c5f112386050a97/1683788362652-OHHR47KPE93R120TDBGJ/4639edfc-62e4-43d9-ba0b-42993121c7a8.png?",
                            Name = "NordicTrack Commercial 1750 Treadmill",
                            Price = 2299.99m,
                            QuantityAvailable = 8,
                            StoreId = 3
                        },
                        new
                        {
                            Id = 17,
                            Category = "Fitness Equipment",
                            DateAdded = new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Deep tissue muscle treatment with customizable speed settings.",
                            ImageUrl = "https://m.media-amazon.com/images/I/61HwDKWhdML.jpg",
                            Name = "Theragun Elite Percussion Massager",
                            Price = 399.99m,
                            QuantityAvailable = 12,
                            StoreId = 3
                        },
                        new
                        {
                            Id = 18,
                            Category = "Fitness Equipment",
                            DateAdded = new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Advanced fitness tracker with heart rate monitoring and GPS.",
                            ImageUrl = "https://m.media-amazon.com/images/I/61wn2jfhBkL.jpg",
                            Name = "Fitbit Charge 6",
                            Price = 149.99m,
                            QuantityAvailable = 20,
                            StoreId = 3
                        },
                        new
                        {
                            Id = 19,
                            Category = "Fitness Equipment",
                            DateAdded = new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Heavy-duty air bike with reinforced steel construction.",
                            ImageUrl = "https://i0.wp.com/asmanyreviewsaspossible.com/wp-content/uploads/2017/12/echo-bike-slider-5-new.jpg",
                            Name = "Rogue Echo Bike",
                            Price = 795.00m,
                            QuantityAvailable = 7,
                            StoreId = 3
                        },
                        new
                        {
                            Id = 20,
                            Category = "Fitness Equipment",
                            DateAdded = new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lightweight percussion massage gun for muscle recovery.",
                            ImageUrl = "https://mygalf.com/uploads/product_image/1669367949Hypervolt2_MainPic.jpeg",
                            Name = "Hyperice Hypervolt Go 2",
                            Price = 129.99m,
                            QuantityAvailable = 18,
                            StoreId = 3
                        },
                        new
                        {
                            Id = 21,
                            Category = "Fitness Equipment",
                            DateAdded = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Multi-function bodyweight trainer designed for push-ups, pull-ups, dips, squats, and more.",
                            ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.bowflex.com%2Fon%2Fdemandware.static%2F-%2FSites-nautilus-master-catalog%2Fdefault%2Fdwef1d0694%2Fimages%2Fbowflex%2Fhome-gyms%2Fbodytower%2Fbowflex-body-tower-home-gym-100243.png&f=1&nofb=1&ipt=f425033fd1393ed3a30be0fb314a557a5ab26041e395a47222128ad035a03fca&ipo=images",
                            Name = "Bowflex BodyTower",
                            Price = 399.99m,
                            QuantityAvailable = 9,
                            StoreId = 3
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sellers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = 2,
                            Username = "TionB"
                        },
                        new
                        {
                            Id = 2,
                            UserId = 1,
                            Username = "Rob90"
                        },
                        new
                        {
                            Id = 3,
                            UserId = 3,
                            Username = "BeachVibes98"
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SellerId")
                        .HasColumnType("integer");

                    b.Property<string>("StoreImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "PC Parts",
                            SellerId = 1,
                            StoreImageUrl = "images.unsplash.com/photo-1568209865332-a15790aed756?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sports Products",
                            SellerId = 1,
                            StoreImageUrl = "jhrvt.com/uploads/gallery/658/Photos_Website_Banners(2).jpeg"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Fitness Equipment",
                            SellerId = 1,
                            StoreImageUrl = "valorfitness.com/cdn/shop/files/valor-fitness-equipment-retail-store-pinellas_600x600@2x.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Update me",
                            SellerId = 3,
                            StoreImageUrl = ""
                        });
                });

            modelBuilder.Entity("Bangazon.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsSeller")
                        .HasColumnType("boolean");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsSeller = false,
                            Uid = "zmwuMjpI5RXABj6mImfK2O586Qf1"
                        },
                        new
                        {
                            Id = 2,
                            IsSeller = false,
                            Uid = "eBBiuMs6zCYuRFk5657mXQBemjh1"
                        },
                        new
                        {
                            Id = 3,
                            IsSeller = true,
                            Uid = "change-me-2"
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Customer", b =>
                {
                    b.HasOne("Bangazon.Models.Seller", null)
                        .WithMany("Customers")
                        .HasForeignKey("SellerId");

                    b.HasOne("Bangazon.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
                {
                    b.HasOne("Bangazon.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bangazon.Models.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bangazon.Models.Seller", null)
                        .WithMany("Orders")
                        .HasForeignKey("SellerId");

                    b.Navigation("Customer");

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("Bangazon.Models.OrderItems", b =>
                {
                    b.HasOne("Bangazon.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bangazon.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Bangazon.Models.PaymentMethod", b =>
                {
                    b.HasOne("Bangazon.Models.Customer", "Customer")
                        .WithMany("PaymentMethods")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.HasOne("Bangazon.Models.Seller", null)
                        .WithMany("Products")
                        .HasForeignKey("SellerId");

                    b.HasOne("Bangazon.Models.Store", "Store")
                        .WithMany("Products")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Bangazon.Models.Seller", b =>
                {
                    b.HasOne("Bangazon.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bangazon.Models.Store", b =>
                {
                    b.HasOne("Bangazon.Models.Seller", "Seller")
                        .WithMany("Stores")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("Bangazon.Models.Customer", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("PaymentMethods");
                });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Bangazon.Models.Seller", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Orders");

                    b.Navigation("Products");

                    b.Navigation("Stores");
                });

            modelBuilder.Entity("Bangazon.Models.Store", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
