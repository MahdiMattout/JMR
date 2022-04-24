using System.ComponentModel.DataAnnotations;

namespace JMR.Models;

public class IUser
{
  [Key]
  public int userId {get;set;}


  public string? FName {get;set;}

  public string? LName{get;set;}

  [Range(1970, 2004)]
  public int birthYear{get;set;}
  public string getUserInitials(){
    return FName[0].ToString().ToUpper() + LName[0].ToString().ToUpper();
  }
}
