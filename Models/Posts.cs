using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
namespace JMR.Models;

public class Post
{
  [Key]
  public int Id { get; set; }

  public string? Description { get; set; }

  public int minPay { get; set; }
  public int maxPay { get; set; }
  public string priceRange(){
    return minPay.ToString() + " - " + maxPay.ToString() + "$";
  }

  public List<PostIdSkillId> queryPostSkillIds() {
    using (var db = new BloggingContext())
    {
      return db.PostSkillIds.Where(postSkill => postSkill.postId == Id).ToList();
    }
  }
  public List<int> extractSkillIds(){
    List<PostIdSkillId> postSkillIds = queryPostSkillIds();
    List<int> skillIds = new List<int>();
    foreach(var postSkillid in postSkillIds){
      skillIds.Add(postSkillid.skillId);
    }
    return skillIds;
  }
  public string _querySkillName(int skillId){
    using (var db = new BloggingContext())
    {
      return db.RequiredSkills.Single(RS => RS.Id == skillId).skillName;
    }
  }
  public List<string> queryRequiredSkills(List<int> skillIds){
    List<string> requiredSkillsNames = new List<string>();
    foreach(var skillId in skillIds){
      requiredSkillsNames.Add(_querySkillName(skillId));
    }
    return requiredSkillsNames;
  }
  public List<string> GetRequiredSkills(){
    using (var db = new BloggingContext()){
      return queryRequiredSkills(extractSkillIds());
    }
  }
}
