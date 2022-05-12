using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JMR.Models;
using Microsoft.AspNetCore.Authorization;
using JMR.helpers;

namespace JMR.Controllers;

public class HomeController : Controller
{
  [Authorize]
    public IActionResult Index()
    {

    using (var db = new BloggingContext())
    {
      var credentialId = db.credentials.Single(c => c.Email == AuthHelpers.getUserEmail(HttpContext)).Id;
      var User = db.Users.Single(user => user.CredentialId == credentialId);
      ViewBag.Posts = db.Posts.ToList();
      ViewBag.Initials = User.getUserInitials();
    }
    return View();
    }
    [Authorize]
    [HttpGet]
    public IActionResult Index(string searchString){
      IEnumerable<Post> posts;
      using (var db = new BloggingContext()) { 
      posts = db.Posts.ToList();
      var userId = AuthHelpers.getUserId(HttpContext);
      ViewBag.Initials = db.Users.Find(userId).getUserInitials();
      }
      if (!string.IsNullOrEmpty(searchString)){
        posts = posts.Where(p => p.Title!.Contains(searchString));
      }
      else{
      RedirectToAction("Index");
      }
      ViewBag.Posts = posts;
      return View();
    } 
    [Authorize]
    [HttpGet]
    public IActionResult Create()
    {
      ViewBag.RequiredSkills = new RequiredSkill().getAllRequiredSkills();
    using (var db = new BloggingContext())
    {
      var userId = AuthHelpers.getUserId(HttpContext);
      ViewBag.Initials = db.Users.Find(userId).getUserInitials();
    }
    return View();
    }

    [HttpPost]
    public IActionResult Create(PostViewModel post)
    {
      int userId = AuthHelpers.getUserId(HttpContext);
    if (ModelState.IsValid)
    {
      List<PostIdSkillId> postIdSkillIds = new List<PostIdSkillId>();
      int postId;
      var Title = post.Title;
      var description = post.Description;
      var minpay = post.minPay;
      var maxPay = post.maxPay;
      var timeFrame = post.timeFrame;
      var timeUnit = post.timeUnit;
      Post postToInsert = new Post { Title = Title, Description = description, minPay = minpay, maxPay = maxPay, timeFrame = timeFrame, timeUnit = timeUnit, userId = userId};
      using (var db = new BloggingContext())
      {
        db.Add<Post>(postToInsert);
        db.SaveChanges();
        postId = db.Posts.OrderByDescending(p => p.Id).FirstOrDefault().Id;
      }
      Console.WriteLine(post.skillsIds[0]);
      foreach (var skillId in post.skillsIds)
      {
          try
          {
            postIdSkillIds.Add(new PostIdSkillId { postId = postId, skillId = Int32.Parse(skillId) });
          }catch{
              // return View(post);
          }
      }
      using (var db = new BloggingContext())
      {
        // db.Add<Post>(postToInsert);
        db.PostSkillIds.AddRange(postIdSkillIds);
        db.SaveChanges();
      }
    return RedirectToAction("Index");
    }
    ViewBag.RequiredSkills = new RequiredSkill().getAllRequiredSkills();
    return View();
  }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public IActionResult Delete(int postId){
    using (var db = new BloggingContext()){
        db.Remove<Post>(db.Posts.Where(p => p.Id == postId).First());
        db.SaveChanges();
    }
    return RedirectToAction("Index");
  }
  [Authorize]
  public IActionResult MyPosts(){
    using (var db = new BloggingContext())
    {
      var userId = AuthHelpers.getUserId(HttpContext);
      ViewBag.Initials = db.Users.Find(userId).getUserInitials();
      ViewBag.myPosts = db.Posts.Where(p => p.userId == AuthHelpers.getUserId(HttpContext)).ToList();
    }
    return View();
  }
}
