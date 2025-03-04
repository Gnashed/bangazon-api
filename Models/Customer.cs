using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class Customer
{
  public int Id { get; set; }
  [Required]
  public string FirstName { get; set; }
  [Required]
  public string LastName { get; set; }
  [Required]
  public string Address { get; set; }
  [Required]
  public string City { get; set; }
  [Required]
  public string State { get; set; }
  public int Zip { get; set; }
  public int UserId { get; set; } // Fk
  public User User { get; set; }
  // Remember that EF Core can infer that UserId is a foreign key to User. It will create
  // a foreign key constraint on this column when it creates the DB.
}