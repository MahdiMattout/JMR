using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JMR.Models;

public class Post
{
  [Key]
  public int postId { get; set; }

  public string? Description { get; set; }

  [ForeignKey("RequiredSkillsId")]
  public int RequiredSkillsId { get; set; }
  public int minPay { get; set; }
  public int maxPay { get; set; }
  public string priceRange(){
    return minPay.ToString() + " - " + maxPay.ToString() + "$";
  }
  // public List<string> GetRequiredSkills(){
  //   using (var context = new BloggingContext()){
  //     return context.PostRequiredSkills.Single(RS => RS.Id == RequiredSkillsId).RequiredSkillsList;
  //   }
  // }
}
