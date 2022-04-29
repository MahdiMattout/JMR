// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

namespace JMR.Models;

public class RequiredSkill
{
  public int Id { get; set; }
  public string? skillName { get; set; } = "";
  public List<string> getAllRequiredSkills(){
    List<string> skillsNames = new List<string>();
    using (var db = new BloggingContext()){
      List<RequiredSkill> requiredSkills = db.RequiredSkills.ToList();
      foreach (var skill in requiredSkills){
        skillsNames.Add(skill.skillName);
      }
    }
    return skillsNames;
  }
}
