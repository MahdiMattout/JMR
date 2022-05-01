using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JMR.Models;

namespace JMR.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // public static List<Post> posts = new List<Post>();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        using (var db = new BloggingContext())
        {
            ViewBag.Posts = db.Posts.ToList();
        }
        return View();
    }

    public IActionResult CreateForm()
    {
        ViewBag.RequiredSkills = new RequiredSkill().getAllRequiredSkills();
        return View();
    }

    [HttpPost]
    public IActionResult Create(Post post)
    {
    var description = post.Description;
    var minpay = post.minPay;
    var maxPay = post.maxPay;
    Post postToInsert = new Post { Description = description, minPay = minpay, maxPay = maxPay };
    var skillIds = postToInsert.extractSkillIds();
    using (var db = new BloggingContext()){
      db.Add<Post>(postToInsert);
      foreach (var skillId in skillIds){
        db.Add<PostIdSkillId>(new PostIdSkillId { postId = postToInsert.Id, skillId = skillId });
      }
      db.SaveChanges();
    }
    return RedirectToAction("Index");
  }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
