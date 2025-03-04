namespace Bangazon.Models;

public class OrderItems
{
  public int Id { get; set; }
  public int OrderId { get; set; } // FK
  public Order Order { get; set; }
  public int ProductId { get; set; } // FK
  public Product Product { get; set; }
}