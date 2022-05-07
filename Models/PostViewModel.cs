using System.ComponentModel.DataAnnotations;

namespace JMR.Models
{
  public class PostViewModel
  {
    [Required(ErrorMessage = "Please Enter a title for the position.")]
    public string? Title { get; set; } = "Title";
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
    public List<string> skillsIds { get; set; }
  }
}
