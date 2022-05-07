using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JMR.Models;
// using Microsoft.AspNetCore.Authorization;

namespace JMR.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        using (var db = new BloggingContext())
        {
            ViewBag.Posts = db.Posts.ToList();
        }
        return View();
    }

    [HttpGet]
    public IActionResult Index(string searchString){
        IEnumerable<Post> posts;
        using (var db = new BloggingContext()) { posts = db.Posts.ToList(); }
        if (!string.IsNullOrEmpty(searchString)){
                posts = posts.Where(p => p.Title!.Contains(searchString));
        }
        else{
        RedirectToAction("Index");
        }
        ViewBag.Posts = posts;
        return View();
    } 

    public IActionResult Create()
    {
        ViewBag.RequiredSkills = new RequiredSkill().getAllRequiredSkills();
        return View();
    }

    [HttpPost]
    public IActionResult Create(PostViewModel post)
    {
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
      Post postToInsert = new Post { Title = Title, Description = description, minPay = minpay, maxPay = maxPay, timeFrame = timeFrame, timeUnit = timeUnit };
      using (var db = new BloggingContext())
      {
        db.Add<Post>(postToInsert);
        db.SaveChanges();
        postId = db.Posts.OrderByDescending(p => p.Id).FirstOrDefault().Id;
      }
      foreach (var skillId in post.skillsIds)
      {
          try
          {
            postIdSkillIds.Add(new PostIdSkillId { postId = postId, skillId = Int32.Parse(skillId) });
          }catch{
              return View(post);
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
    return View(post);
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
}
