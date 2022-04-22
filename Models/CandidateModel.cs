using System.ComponentModel.DataAnnotations;

namespace JMR.Models;

public class Candidate : IUser
{
  [Key]
  [Required]
  public int userId { get; set; }

  [Required]
  public string FName { get; set; } = "";

  [Required]
  public string LName { get; set; } = "";

  [Required]
  [Range(1970, 2004)]
  public int birthYear { get; set; }
  public int yearsOfExperience(int value)
  {
    return DateTime.Now.Year - value;
  }
}
