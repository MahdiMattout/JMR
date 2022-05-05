using System.ComponentModel.DataAnnotations;

namespace JMR.Models;

public class PostIdSkillId
{
  [Key]
  public int Id { get; set; }
  public int postId { get; set; }
  public int skillId { get; set; }
}
