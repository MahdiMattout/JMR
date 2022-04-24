using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JMR.Models;

namespace JMR.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult SignUp()
    {
        return View();
    }
    
    }
}