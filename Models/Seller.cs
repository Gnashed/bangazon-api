using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class Seller
{
  public int Id { get; set; }
  public int  StoreId { get; set; } // FK
  [Required]
  public string Username { get; set; }
  public int UserId { get; set; } // FK
  public User User { get; set; }
  public List<Store> Stores { get; set; }
  public List<Customer> Customers { get; set; }
  public List<Order> Orders { get; set; }
  public List<Product> Products { get; set; }
  // Remember that EF Core can infer that UserId is a foreign key to User. It will create
  // a foreign key constraint on this column when it creates the DB.
}