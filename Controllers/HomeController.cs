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

    public IActionResult CreateForm()
    {
        ViewBag.RequiredSkills = new RequiredSkill().getAllRequiredSkills();
        return View();
    }

    [HttpPost]
    public IActionResult Create(Post post, string Python, string SQL, string Cpp, string CSharp )
    {
        List<PostIdSkillId> postIdSkillIds = new List<PostIdSkillId>();
        List<int> skills = new List<int>();
        int postId;
        using (var db = new BloggingContext()){
            db.Add<Post>(post);
            db.SaveChanges();
            postId = db.Posts.OrderByDescending(p => p.Id).FirstOrDefault().Id;
            if (Python == "check") { skills.Add(db.RequiredSkills.Single(r => r.skillName == "Python").Id); }
            if (SQL == "check") { skills.Add(db.RequiredSkills.Single(r => r.skillName == "SQL").Id); }
            if (Cpp == "check") { skills.Add(db.RequiredSkills.Single(r => r.skillName == "Cpp").Id); }
    }
        foreach (var skillId in skills) {
            postIdSkillIds.Add(new PostIdSkillId { postId = postId, skillId = skillId });
        }
        // TODO() records aren't inserted in PostSkillIds
        using (var db = new BloggingContext()){
            // db.Add<Post>(postToInsert);
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

    public IActionResult Delete(int postId){

        return RedirectToAction("Index");
  }
}
