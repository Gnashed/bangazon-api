using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class User
{
  public int Id { get; set; }
  public bool IsSeller { get; set; }
  [Required]
  public string Uid { get; set; }
}