namespace Bangazon.Models;

// In your class files, to establish a many-to-many relationship, you need to make sure the JOIN table (this table)
// has the foreign keys from both end tables of the JOIN table (Product and Order). The next step is to configure the many-
// to-many relationship using Fluent API in BangazonDbContext by configuring both foreign keys to be the composite key.
public class OrderItems
{
  public int OrderId { get; set; } // FK
  public Order Order { get; set; }
  public int ProductId { get; set; } // FK
  public Product Product { get; set; }
  public int ItemQuantity { get; set; }
}