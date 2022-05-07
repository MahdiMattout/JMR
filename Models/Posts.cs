using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
namespace JMR.Models;

public class Post
{
  [Key]
  public int Id { get; set; }
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
  // [ForeignKey("User")]
  // public int userId { get; set; }
  public string priceRange(){
    if (minPay == 0 && maxPay == 0) { return "Free"; }
    return minPay.ToString() + " - " + maxPay.ToString() + "$";
  }
  public List<PostIdSkillId> queryPostSkillIds() {
    using (var db = new BloggingContext())
    {
      return db.PostSkillIds.Where(postSkill => postSkill.postId == Id).ToList();
    }
  }
  public List<RequiredSkill> extractSkills()
  {
    List<PostIdSkillId> postSkillIds = queryPostSkillIds();
    List<RequiredSkill> skills = new List<RequiredSkill>();
    using (var db = new BloggingContext())
    {
      foreach (var postSkillId in postSkillIds)
      {
        skills.Add(db.RequiredSkills.Single(s => s.Id == postSkillId.skillId));
      }
    }
    return skills;
  }
}
