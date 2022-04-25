using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JMR.Models;

public class Post
{
  [Key]
  public int postId { get; set; }

  public string? Description { get; set; }

  public int minPay { get; set; }
  public int maxPay { get; set; }
  public string priceRange(){
    return minPay.ToString() + " - " + maxPay.ToString() + "$";
  }
  public List<RequiredSkills> GetRequiredSkills(){
    using (var db = new BloggingContext()){
      return db.RequiredSkills.Where(RS => RS.userId == postId).ToList();
    }
  }
}
