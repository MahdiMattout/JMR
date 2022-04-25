using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMR.Models;

public class RequiredSkills 
{
  public int Id { get; set; }
  [ForeignKey("Posts")]
  public int userId { get; set; }
  public string requiredSkill { get; set; } = "";
}
