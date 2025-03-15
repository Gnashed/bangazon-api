// The DbContext class file will be able to access the PostgreSQL database and seed the
// database with data.

using Microsoft.EntityFrameworkCore;
using Bangazon.Models;

// Remember that DbContext is a class that comes from EF Core that represents the DB as .NET objects that we can access.
// Here, inheritance is being used to passed down members, properties, and fields from the DbContext to the
// BangazonDbContext class.
public class BangazonDbContext : DbContext
{
  public DbSet<Customer> Customers { get; set; }
  public DbSet<Order> Orders { get; set; }
  public DbSet<OrderItems> OrderItems { get; set; }
  public DbSet<PaymentMethod> PaymentMethods { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<Seller> Sellers { get; set; }
  public DbSet<Store> Stores { get; set; }
  public DbSet<User> Users { get; set; }
  
  public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context) { }

  // Remember protected means that the method can only be called from code inside the class itself, or by
  // any class that inherits it. This is a form of encapsulation.
  // Each time we create/update the DB schema, this method will check whether this data is in the DB or not,
  // and will attempt to add it if it doesn't find it at all.
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Seed data.
    modelBuilder.Entity<User>().HasData(new User[]
    {
      new User {Id = 1, Uid = "zmwuMjpI5RXABj6mImfK2O586Qf1", IsSeller = false}, // Uid is auth'd using email+password combo.
      new User {Id = 2, Uid = "eBBiuMs6zCYuRFk5657mXQBemjh1", IsSeller = false},
      new User {Id = 3, Uid = "change-me-2", IsSeller = true},
    });
    
    modelBuilder.Entity<Customer>().HasData(new Customer[]
    {
      new Customer
      {
        Id = 1, FirstName = "Tion", LastName = "Blackmon", Address = "1234 Apple Rd.",
        City = "Nashville", State = "TN", ZipCode = 37000, UserId = 1
      },
      new Customer
      {
        Id = 2, FirstName = "Admin", LastName = "(SWE)", Address = "HQ",
        City = "Nashville", State = "TN", ZipCode = 37000, UserId = 2
      },
    });
    
    modelBuilder.Entity<PaymentMethod>().HasData(new PaymentMethod[]
    {
      new PaymentMethod 
      {
        Id = 1, 
        CardNumber = "4444-4444-4444-4444", 
        ExpirationDate = new DateTime(2028, 5, 9),
        SecurityCode = 778,
        CustomerId = 1,
      }
    });

    modelBuilder.Entity<Seller>()
      .HasMany(s => s.Stores)
      .WithOne(st => st.Seller)
      .HasForeignKey(st => st.SellerId);
    modelBuilder.Entity<Seller>().HasData(new Seller[]
    {
      new Seller { Id = 1, Username = "TionB", UserId = 2 },
      new Seller { Id = 2, Username = "Rob90", UserId = 1 },
      new Seller { Id = 3, Username = "BeachVibes98", UserId = 3 },
    });
    
    modelBuilder.Entity<Store>().HasData(new Store[]
    {
      new Store { Id = 1, Name = "PC Parts", SellerId = 1, StoreImageUrl = "images.unsplash.com/photo-1568209865332-a15790aed756?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"},
      new Store { Id = 2, Name = "Sports Products", SellerId = 1, StoreImageUrl = "jhrvt.com/uploads/gallery/658/Photos_Website_Banners(2).jpeg"},
      new Store { Id = 3, Name = "Fitness Equipment", SellerId = 1, StoreImageUrl = "valorfitness.com/cdn/shop/files/valor-fitness-equipment-retail-store-pinellas_600x600@2x.jpg"},
      new Store { Id = 4, Name = "Update me", SellerId = 3, StoreImageUrl = ""},
    });
    
    modelBuilder.Entity<Product>().HasData(new Product[]
    {
      new Product
      {
          Id = 1, 
          Category = "Graphics Cards", 
          Name = "EVGA GeForce RTX 3060 XC 12GB", 
          Description = "The EVGA GeForce RTX 3060 12GB provides players with the ability to vanquish 1080p and 1440p gaming...",
          Price = 250_00M, 
          QuantityAvailable = 25, 
          StoreId = 1,
          ImageUrl = "https://i.pinimg.com/originals/8c/4a/a4/8c4aa4434669caabab3ef0e0fea4958d.jpg",
          DateAdded = new DateTime(2025, 3, 14)
      },
      new Product
      {
          Id = 2, 
          Category = "Processors", 
          Name = "AMD Ryzen 7 5800X", 
          Description = "The AMD Ryzen 7 5800X is built on the Zen 3 architecture, offering 8 cores and 16 threads...",
          Price = 350_00M, 
          QuantityAvailable = 15, 
          StoreId = 1,
          ImageUrl = "https://www.techinn.com/f/13795/137954422/amd-ryzen-7-5800x-3.8ghz.jpg",
          DateAdded = new DateTime(2025, 3, 12)
      },
      new Product
      {
          Id = 3, 
          Category = "Motherboards", 
          Name = "ASUS ROG Strix B550-F Gaming", 
          Description = "The ASUS ROG Strix B550-F Gaming motherboard is designed for AMD Ryzen processors...",
          Price = 180_00M, 
          QuantityAvailable = 10, 
          StoreId = 1,
          ImageUrl = "https://images.anandtech.com/doci/15868/ROG-STRIX-B550-F-GAMING-WI-FI-What_s-inside-the-Box.jpg",
          DateAdded = new DateTime(2025, 3, 10)
      },
      new Product
      {
          Id = 4, 
          Category = "Memory", 
          Name = "Corsair Vengeance RGB Pro 32GB", 
          Description = "Corsair Vengeance RGB Pro series DDR4 memory is designed for high-performance overclocking...",
          Price = 150_00M, 
          QuantityAvailable = 20, 
          StoreId = 1,
          ImageUrl = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6449/6449223_sd.jpg",
          DateAdded = new DateTime(2025, 3, 8)
      },
      new Product
      {
          Id = 5, 
          Category = "Basketball Products", 
          Name = "Spalding NBA Varsity Basketball (outdoor)", 
          Description = "Official size and weight, indoor/outdoor use.",
          Price = 29_99M, 
          QuantityAvailable = 15, 
          StoreId = 2,
          ImageUrl = "https://cdn4.volusion.store/phzup-xttqn/v/vspfiles/photos/63-306E-2.jpg?v-cache=1640967916",
          DateAdded = new DateTime(2025, 2, 25)
      },
      new Product
      {
          Id = 6, 
          Category = "Basketball Products", 
          Name = "Nike Elite Basketball Shorts", 
          Description = "Lightweight and breathable, with Dri-FIT technology.",
          Price = 45_00M, 
          QuantityAvailable = 30, 
          StoreId = 2,
          ImageUrl = "https://i.ebayimg.com/images/g/YlgAAOSw~WpgqyDw/s-l1200.jpg",
          DateAdded = new DateTime(2025, 2, 28)
      },
      new Product
      {
          Id = 7, 
          Category = "Basketball Products", 
          Name = "Wilson Evolution Basketball", 
          Description = "High-quality composite leather, soft feel and grip.",
          Price = 64_99M, 
          QuantityAvailable = 20, 
          StoreId = 2,
          ImageUrl = "https://i5.walmartimages.com/asr/b624338a-fe3a-4036-92c7-3e5dfc3d41e1_1.660a529a42734dc1008fc53ada274653.jpeg",
          DateAdded = new DateTime(2025, 2, 24)
      },
      new Product
      {
          Id = 8, 
          Category = "Basketball Shoes", 
          Name = "Air Jordan 13 Retro Basketball Shoes (RED/WHITE)", 
          Description = "Iconic design with superior traction and support.",
          Price = 120_00M, 
          QuantityAvailable = 10, 
          StoreId = 2,
          ImageUrl = "https://i.ebayimg.com/00/s/MTI3NlgxMjgw/z/uCMAAOSw0x1k5cIg/$_57.JPG?set_id=8800005007",
          DateAdded = new DateTime(2025, 3, 1)
      },
      new Product
      {
          Id = 9, 
          Category = "Basketball Products", 
          Name = "Adidas Shooting Sleeve", 
          Description = "Compression sleeve for improved circulation and performance.",
          Price = 18_99M, 
          QuantityAvailable = 25, 
          StoreId = 2,
          ImageUrl = "https://i.ebayimg.com/images/g/SRIAAOSwRwFfWx36/s-l1200.jpg",
          DateAdded = new DateTime(2025, 3, 2)
      },
      new Product
      {
          Id = 10, 
          Category = "Basketball Products", 
          Name = "Under Armour Basketball Socks", 
          Description = "Moisture-wicking and cushioned for comfort.",
          Price = 14_99M, 
          QuantityAvailable = 40, 
          StoreId = 2,
          ImageUrl = "https://www.kicksown.com/cdn/shop/files/20240821172318.jpg",
          DateAdded = new DateTime(2025, 3, 3)
      },
      new Product
      {
          Id = 11, 
          Category = "Basketball Products", 
          Name = "Basketball Hoop with Stand", 
          Description = "Adjustable height, weather-resistant material.",
          Price = 199_99M, 
          QuantityAvailable = 5, 
          StoreId = 2,
          ImageUrl = "https://m.media-amazon.com/images/I/61CKDFncGbL._AC_UF1000,1000_QL80_.jpg",
          DateAdded = new DateTime(2025, 3, 4)
      },
      new Product
      {
          Id = 12, 
          Category = "Basketball Products", 
          Name = "Molten Official Game Ball", 
          Description = "Used in official FIBA games, premium feel.",
          Price = 89_99M, 
          QuantityAvailable = 12, 
          StoreId = 2,
          ImageUrl = "https://shop.moltensports.jp/cdn/shop/articles/20210902_01_01.png?v=1644331911",
          DateAdded = new DateTime(2025, 3, 5)
      },
      new Product
      {
          Id = 13,
          Category = "Fitness Equipment",
          Name = "Bowflex SelectTech 552 Adjustable Dumbbells",
          Description = "Pair of adjustable dumbbells with weight range from 5 to 52.5 lbs.",
          Price = 349_99M,
          QuantityAvailable = 10,
          StoreId = 3,
          ImageUrl = "https://www.bowflex.com/dw/image/v2/AAYW_PRD/on/demandware.static/-/Sites-nautilus-master-catalo" +
                     "g/default/dwf21fb1cf/images/bfx/weights/100131/bowflex-selecttech-552-dumbbell-weights-hero.jpg?s" +
                     "w=2600&sh=1464&sm=fit",
          DateAdded = new DateTime(2025, 3, 6)
      },
      new Product
      {
          Id = 14,
          Category = "Fitness Equipment",
          Name = "Peloton Bike+",
          Description = "High-end stationary bike with live and on-demand classes.",
          Price = 2495_00M,
          QuantityAvailable = 5,
          StoreId = 3,
          ImageUrl = "https://res.cloudinary.com/peloton-cycle/image/fetch/dpr_2.0,f_auto,q_auto:good,w_768/https://ima" +
                     "ges.ctfassets.net/7vk8puwnesgc/570NDQUa4nJVo466mxbUuv/f55258ef9420c35a68da5d5f22146184/20_5632" +
                     "_PELOTON_BIKE_RENDERS_TITAN-ALT_M_BOTH_W1_F_LAYERED_NO_WEIGHTS.jpg",
          DateAdded = new DateTime(2025, 3, 7)
      },
      new Product
      {
          Id = 15,
          Category = "Fitness Equipment",
          Name = "TRX Suspension Trainer",
          Description = "Portable, full-body workout system using suspension straps.",
          Price = 199_99M,
          QuantityAvailable = 15,
          StoreId = 3,
          ImageUrl = "https://www.trxtraining.com/cdn/shop/products/21_09_03_Lifestyle_Yoga9924_1_1800x.jpg",
          DateAdded = new DateTime(2025, 3, 8)
      },
      new Product
      {
          Id = 16,
          Category = "Fitness Equipment",
          Name = "NordicTrack Commercial 1750 Treadmill",
          Description = "High-end treadmill with incline and interactive training.",
          Price = 2299_99M,
          QuantityAvailable = 8,
          StoreId = 3,
          ImageUrl = "https://images.squarespace-cdn.com/content/v1/5d910d397c5f112386050a97/1683788362652-OHHR47KPE93" +
                     "R120TDBGJ/4639edfc-62e4-43d9-ba0b-42993121c7a8.png?",
          DateAdded = new DateTime(2025, 3, 9)
      },
      new Product
      {
          Id = 17,
          Category = "Fitness Equipment",
          Name = "Theragun Elite Percussion Massager",
          Description = "Deep tissue muscle treatment with customizable speed settings.",
          Price = 399_99M,
          QuantityAvailable = 12,
          StoreId = 3,
          ImageUrl = "https://m.media-amazon.com/images/I/61HwDKWhdML.jpg",
          DateAdded = new DateTime(2025, 3, 10)
      },
      new Product
      {
          Id = 18,
          Category = "Fitness Equipment",
          Name = "Fitbit Charge 6",
          Description = "Advanced fitness tracker with heart rate monitoring and GPS.",
          Price = 149_99M,
          QuantityAvailable = 20,
          StoreId = 3,
          ImageUrl = "https://m.media-amazon.com/images/I/61wn2jfhBkL.jpg",
          DateAdded = new DateTime(2025, 3, 11)
      },
      new Product
      {
          Id = 19,
          Category = "Fitness Equipment",
          Name = "Rogue Echo Bike",
          Description = "Heavy-duty air bike with reinforced steel construction.",
          Price = 795_00M,
          QuantityAvailable = 7,
          StoreId = 3,
          ImageUrl = "https://i0.wp.com/asmanyreviewsaspossible.com/wp-content/uploads/2017/12/echo-bike-slider-5-new.jpg",
          DateAdded = new DateTime(2025, 3, 12)
      },
      new Product
      {
          Id = 20,
          Category = "Fitness Equipment",
          Name = "Hyperice Hypervolt Go 2",
          Description = "Lightweight percussion massage gun for muscle recovery.",
          Price = 129_99M,
          QuantityAvailable = 18,
          StoreId = 3,
          ImageUrl = "https://mygalf.com/uploads/product_image/1669367949Hypervolt2_MainPic.jpeg",
          DateAdded = new DateTime(2025, 3, 13)
      },
      new Product
      {
        Id = 21,
        Category = "Fitness Equipment",
        Name = "Bowflex BodyTower",
        Description = "Multi-function bodyweight trainer designed for push-ups, pull-ups, dips, squats, and more.",
        Price = 399.99M,
        QuantityAvailable = 9,
        StoreId = 3,
        ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.bowflex.com%2Fon%2Fdemandware.stati" +
                   "c%2F-%2FSites-nautilus-master-catalog%2Fdefault%2Fdwef1d0694%2Fimages%2Fbowflex%2Fhome-gyms%2Fbodyto" +
                   "wer%2Fbowflex-body-tower-home-gym-100243.png&f=1&nofb=1&ipt=f425033fd1393ed3a30be0fb314a557a5ab2604" +
                   "1e395a47222128ad035a03fca&ipo=images",
        DateAdded = new DateTime(2025, 3, 15),
      }
    });
    
    modelBuilder.Entity<Order>().HasData(new Order[]
    {
      new Order
      {
        Id = 1, 
        IsCompleted = true, 
        OrderTotal = 250_00, 
        OrderDate = DateTime.Now, 
        CustomerId = 1, 
        PaymentMethodId = 1,
      }
    });
    
    modelBuilder.Entity<OrderItems>().HasData(new OrderItems[]
    {
      new OrderItems { Id = 1, OrderId = 1, ProductId = 1 },
    });
  }
}