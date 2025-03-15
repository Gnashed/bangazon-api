using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class Seller
{
  public int Id { get; set; }
  [Required]
  public string Username { get; set; }
  public int UserId { get; set; } // FK
  public User User { get; set; }
  public List<Store> Stores { get; set; } = new List<Store>();
  public List<Customer> Customers { get; set; } = new List<Customer>();
  public List<Order> Orders { get; set; } =  new List<Order>();
  public List<Product> Products { get; set; } = new List<Product>();
  // Remember that EF Core can infer that UserId is a foreign key to User. It will create
  // a foreign key constraint on this column when it creates the DB.
}