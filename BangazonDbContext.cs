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
      new User {Id = 2, Uid = "change-me", IsSeller = false},
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
    
    modelBuilder.Entity<Seller>().HasData(new Seller[]
    {
      new Seller { Id = 1, StoreId = 999, Username = "Admin_SWE", UserId = 3 },
    });
    
    modelBuilder.Entity<Store>().HasData(new Store[]
    {
      new Store { Id = 1, Name = "Admin Store", SellerId = 1},
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
          Name = "Spalding NBA Basketball", 
          Description = "Official size and weight, indoor/outdoor use.",
          Price = 29_99M, 
          QuantityAvailable = 15, 
          StoreId = 2,
          ImageUrl = "spalding_nba_ball.jpg",
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
          ImageUrl = "nike_elite_shorts.jpg",
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
          ImageUrl = "wilson_evolution.jpg",
          DateAdded = new DateTime(2025, 2, 24)
      },
      new Product
      {
          Id = 8, 
          Category = "Basketball Products", 
          Name = "Jordan Jumpman Basketball Shoes", 
          Description = "Iconic design with superior traction and support.",
          Price = 120_00M, 
          QuantityAvailable = 10, 
          StoreId = 2,
          ImageUrl = "jordan_jumpman_shoes.jpg",
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
          ImageUrl = "adidas_shooting_sleeve.jpg",
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
          ImageUrl = "ua_basketball_socks.jpg",
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
          ImageUrl = "basketball_hoop.jpg",
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
          ImageUrl = "molten_game_ball.jpg",
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
          ImageUrl = "bowflex_selecttech.jpg",
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
          ImageUrl = "peloton_bike.jpg",
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
          ImageUrl = "trx_trainer.jpg",
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
          ImageUrl = "nordictrack_treadmill.jpg",
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
          ImageUrl = "theragun_elite.jpg",
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
          ImageUrl = "fitbit_charge6.jpg",
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
          ImageUrl = "rogue_echo_bike.jpg",
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
          ImageUrl = "hypervolt_go2.jpg",
          DateAdded = new DateTime(2025, 3, 13)
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