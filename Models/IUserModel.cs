using System.ComponentModel.DataAnnotations;

namespace JMR.Models;

public interface IUser
{
  [Key]
  [Required]
  public int userId;

  [Required]
  public string FName;

  [Required]
  public string LName;

  [Required]
  [Range(1970, 2004)]
  public int birthYear;
}
