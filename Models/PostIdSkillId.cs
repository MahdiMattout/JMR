// using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMR.Models;

public class PostIdSkillId
{
  public int postId { get; set; }
  [ForeignKey("RequiredSkills")]
  public int skillId { get; set; }
}