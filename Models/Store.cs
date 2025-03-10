using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class Store
{
  public int Id { get; set; }
  [Required]
  public string Name { get; set; }
  public int SellerId { get; set; } // FK
  public Seller Seller { get; set; }
}