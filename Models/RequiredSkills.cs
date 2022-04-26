using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMR.Models;

public class RequiredSkills 
{
  public int Id { get; set; }
  public string skillName { get; set; }
}
