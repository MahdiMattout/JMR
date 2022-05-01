using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JMR.Models;

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

    public IActionResult CreateForm()
    {
        ViewBag.RequiredSkills = new RequiredSkill().getAllRequiredSkills();
        return View();
    }

    [HttpPost]
    public IActionResult Create(Post post)
    {
        List<PostIdSkillId> postIdSkillIds = new List<PostIdSkillId>();
        var description = post.Description;
        var minpay = post.minPay;
        var maxPay = post.maxPay;
        Post postToInsert = new Post { Description = description, minPay = minpay, maxPay = maxPay };
        var skillIds = postToInsert.extractSkillIds();
        foreach (var skillId in skillIds) {
            postIdSkillIds.Add(new PostIdSkillId { postId = post.Id, skillId = skillId });
        }
        // TODO() records aren't inserted in PostSkillIds
        using (var db = new BloggingContext()){
            db.Add<Post>(postToInsert);
            db.PostSkillIds.AddRange(postIdSkillIds);
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
