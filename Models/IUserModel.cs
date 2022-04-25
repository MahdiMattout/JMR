using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JMR.Models;

public class IUser
{
  [Key]
  public int userId {get;set;}
  [Required]
  public string? FName {get;set;}
  [Required]
  public string? LName{get;set;}

  [Required]
  [Column(TypeName = "datetime2")]
  public DateTime birthDate{get;set;}

}
