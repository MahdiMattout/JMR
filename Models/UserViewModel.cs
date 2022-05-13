using System.ComponentModel.DataAnnotations;

namespace JMR.Models
{
  public class UserViewModel
  {
    [Required(ErrorMessage = "Name cannot be empty.")]
    public string? Fname { get; set; } = "Fname";
    [Required(ErrorMessage = "Last Name cannot be empty.")]
    public string? Lname { get; set; } = "LName";
  }
}
