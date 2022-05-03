using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JMR.Models;

namespace JMR.Controllers;

public class PostDetailsController : Controller
{
  public IActionResult ViewDetails(int Id, string Days, string Weeks, string Years)
  {
    Post post;
    using (var db = new BloggingContext()){
      post = db.Posts.Single(p => p.Id == Id);
    }
    ViewBag.PositionTitle = post.Title;
    ViewBag.Description = post.Description;
    ViewBag.requiredSkills = post.extractSkills();
    ViewBag.time = post.timeFrame;
    string timeUnit;
    // Years == "check" ? timeUnit="Years" : Weeks == "checked" ? timeUnit = "Weeks" : timeUnit = "Days";
    // ViewBag.PostUser = post.userId;
    return View();
  }
}
