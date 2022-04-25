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

    public IActionResult Create()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
