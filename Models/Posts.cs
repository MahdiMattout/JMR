using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
namespace JMR.Models;

public class Post
{
  [Key]
  public int Id { get; set; }

  public string? Title { get; set; } = "Title";
  public string? Description { get; set; } = "Description";

  public int minPay { get; set; }
  public int maxPay { get; set; }
  public int timeFrame { get; set; }
  public string timeUnit { get; set; }
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
