// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

namespace JMR.Models;

public class RequiredSkill
{
  public int Id { get; set; }
  public string? skillName { get; set; } = "";
  public List<RequiredSkill> getAllRequiredSkills()
  {
    using (var db = new BloggingContext())
    {
      return db.RequiredSkills.ToList();
    }
  }
}
