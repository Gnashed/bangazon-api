using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class PaymentMethod
{
  public int Id { get; set; }
  [Required]
  public string CardNumber { get; set; } // For simplicity, storing this as a string.
  public int SecurityCode { get; set; }
  public DateTime ExpirationDate { get; set; }
  public int CustomerId { get; set; } // FK
  public Customer Customer { get; set; }
  // Remember that EF Core can infer that CustomerId is a foreign key to Customer. It will create
  // a foreign key constraint on this column when it creates the DB.
}