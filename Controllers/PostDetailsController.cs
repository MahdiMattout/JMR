using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JMR.Models;

namespace JMR.Controllers;

public class PostDetailsController : Controller
{
  public IActionResult ViewDetails(int postId)
  {
    Post post;
    using (var db = new BloggingContext()){
      post = db.Posts.Single(p => p.Id == postId);
    }
    ViewBag.PositionTitle = post.Title;
    ViewBag.Description = post.Description;
    ViewBag.requiredSkills = post.extractSkills();
    // ViewBag.time = post.TimeFrame
    // ViewBag.PostUser = post.userId;
    return View();
  }
}
