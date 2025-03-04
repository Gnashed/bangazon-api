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
    modelBuilder.Entity<Customer>().HasData(new Customer[]
    {

    });
    modelBuilder.Entity<Order>().HasData(new Order[]
    {

    });
    modelBuilder.Entity<OrderItems>().HasData(new OrderItems[]
    {

    });    
    modelBuilder.Entity<PaymentMethod>().HasData(new PaymentMethod[]
    {

    });
    modelBuilder.Entity<Product>().HasData(new Product[]
    {

    });
    modelBuilder.Entity<Seller>().HasData(new Seller[]
    {

    });
    modelBuilder.Entity<Store>().HasData(new Store[]
    {

    });
    modelBuilder.Entity<User>().HasData(new User[]
    {

    });
    
  }
}