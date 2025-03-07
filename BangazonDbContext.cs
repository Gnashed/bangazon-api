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
        Description = "The EVGA GeForce RTX 3060 12GB provides players with the ability to vanquish 1080p and " +
                      "1440p gaming, while providing a quality NVIDIA RTX experience and a myriad of productivity " +
                      "benefits. The card is powered by NVIDIA Ampere architecture, which doubles down on ray tracing " +
                      "and AI performance with enhanced RT cores, Tensor Cores, and new streaming multiprocessors. " +
                      "With 12GB of GDDR6 memory, high-end performance does not have to be sacrificed to find a card " +
                      "for gaming and everyday use.",
        Price = 250_00M , 
        QuantityAvailable = 25, 
        StoreId = 1
      },
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