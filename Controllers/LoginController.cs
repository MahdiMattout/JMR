using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JMR.Models;
using JMR.helpers;

namespace JMR.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
    {
        return View();
    }
    public IActionResult submitLogin(LoginViewModel LoginModel)
    {
        string salt = "";
        string DbHashedPassword = "";
        using(var db = new BloggingContext()){
            var credential = db.credentials.Single(c => c.Email == LoginModel.Email);
            salt = credential.passwordSalt;
            DbHashedPassword = credential.Hashedpassword;
        }
        byte [] saltbytes = Convert.FromBase64String(salt);
        string UserHashedPassword = Hashing.generateHash(saltbytes, LoginModel.Password);
        if(UserHashedPassword == DbHashedPassword){
            return RedirectToAction("SignUp");
        }
        return RedirectToAction("Login");
    }
        public IActionResult SignUp()
    {
        return View();
    }
    public IActionResult submitSignUp(SignUpViewModel SignUpModel){
        var salt = Hashing.generateSalt();
        string password = SignUpModel.Password;
        string hash = Hashing.generateHash(salt, password);
        string email = SignUpModel.Email;
        string saltstring = Convert.ToBase64String(salt);
        string Fname = SignUpModel.FName;
        string Lname = SignUpModel.LName;
        IUser dbUser = new IUser {FName=Fname, LName=Lname, birthDate=SignUpModel.birthDate};
        Credentials dbCredentials = new Credentials {Email=email, Hashedpassword=hash, passwordSalt=saltstring};
        using(var db = new BloggingContext()){
            var x = db.credentials.SingleOrDefault(c=>c.Email == email);
            if(x == null){
            db.Add<Credentials>(dbCredentials);
            db.Add<IUser>(dbUser);
            db.SaveChanges();
            return RedirectToAction("Login");
            }
            else{
                ViewBag.Alert = "Email already exists";
                return View("SignUp");
            }
            
        }
    }
    
    }
}