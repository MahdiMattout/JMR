using System.ComponentModel.DataAnnotations;

namespace JMR.Models
{
  public class UserViewModel
  {
    [Required(ErrorMessage = "Name cannot be empty.")]
    public string? Fname { get; set; } = "Fname";
    [Required(ErrorMessage = "Please Enter a description for the position")]
    public string? Description { get; set; } = "Description";
    [Required(ErrorMessage = "Please enter a value greater than 1.")]
    [Range(1, int.MaxValue)]
    public int minPay { get; set; }
    [Required(ErrorMessage = "Please enter a value greater than 1.")]
    [Range(1, int.MaxValue)]
    public int maxPay { get; set; }
    [Required(ErrorMessage = "Please enter a value greater than 1.")]
    public int timeFrame { get; set; }
    [Required(ErrorMessage = "Please select an option between Days, Weeks, or Years.")]
    public string? timeUnit { get; set; }
    [Required(ErrorMessage = "The job must have at least one required skill.")]
    public List<string> skillsIds { get; set; } = new List<string>();
  }
