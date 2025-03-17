// Line 3 Provides attribute classes that are used to define metadata for ASP.NET MVC and ASP.NET data controls.
// This allows us to use the `[Required]` attribute.
// https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-9.0
using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class Product
{
  public int Id { get; set; }
  [Required]
  public string Category { get; set; }
  [Required]
  public string Name { get; set; }
  [Required]
  public string Description { get; set; }
  public decimal Price { get; set; }
  public int QuantityAvailable { get; set; }
  public int StoreId { get; set; } // FK
  public Store Store { get; set; }
  public string ImageUrl { get; set; }
  public DateTime DateAdded { get; set; }
  
  // Collection navigation property
  public IEnumerable<OrderItems> OrderItems { get; set; }
  
  // Remember that EF Core can infer that StoreId is a foreign key to Store. It will create
  // a foreign key constraint on this column when it creates the DB.
}