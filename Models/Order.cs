namespace Bangazon.Models;

public class Order
{
  public int Id { get; set; }
  public bool IsCompleted { get; set; }
  public decimal OrderTotal { get; set; }
  public DateTime OrderDate { get; set; }
  public int CustomerId { get; set; } // FK
  public Customer Customer { get; set; }
  public int PaymentMethodId { get; set; } // FK
  public string OrderStatus { get; set; }
  public DateTime EstimatedDeliveryDate { get; set; }
  public PaymentMethod PaymentMethod { get; set; }
  
  // Collection navigation property
  public IEnumerable<OrderItems> OrderItems { get; set; }
}