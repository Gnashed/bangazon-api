using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class Store
{
  public int Id { get; set; }
  [Required]
  public string Name { get; set; }
  public int SellerId { get; set; } // FK
  public Seller Seller { get; set; }
  public string StoreImageUrl { get; set; }
  // Navigation relationship. A store can have multiple products, a one-to-many relationship.
  public List<Product> Products { get; set; } = new List<Product>();
}