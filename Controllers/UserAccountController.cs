using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JMR.Models;
using JMR.helpers;

namespace JMR.Controllers;

public class UserAccountController : Controller
{
  [Authorize]
  public IActionResult UserProfile()
  {
    using (var db = new BloggingContext()){
      var credentialId = db.credentials.Single(c => c.Email == AuthHelpers.getUserEmail(HttpContext)).Id;
      var User = db.Users.Single(user => user.CredentialId == credentialId);
      ViewBag.Fname = User.FName;
      ViewBag.Lname = User.LName;
      ViewBag.Email = AuthHelpers.getUserEmail(HttpContext);
      ViewBag.Initials = User.getUserInitials();
    }
    return View();
  }

  public IActionResult submitLogout(){
    HttpContext.Session.Clear();
    return RedirectToAction("SignUp","Login");
  }
  [Authorize]
  [HttpPost]
  public IActionResult SaveChanges(UserViewModel user){
    using (var db = new BloggingContext()){
      var User = db.Users.Find(AuthHelpers.getUserId(HttpContext));
      User.FName = user.Fname;
      User.LName = user.Lname;
      db.SaveChanges();
    }
    return RedirectToAction("UserProfile");
  }
}
