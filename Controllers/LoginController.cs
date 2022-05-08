using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
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
    private string GenerateJwtToken(string email, int userId){
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                "Test_key_Now_Here"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            token.Payload["email"] = email;
            token.Payload["UserId"] = userId;
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
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
            int userId;
            IUser user;
            using(var db = new BloggingContext()){
                Credentials credential = db.credentials.Single(x=>x.Email == LoginModel.Email);
                user = db.Users.Single(x=> x.CredentialId == credential.Id);
                userId = user.userId;
            }
            userId = user.userId;
            string token = GenerateJwtToken(LoginModel.Email, userId);
            HttpContext.Session.SetString("Token", token);
            return RedirectToAction("Index","Home");
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
            db.SaveChanges();
            Credentials Insertedcredential = db.credentials.Single(x => x.Email == email);
            dbUser.CredentialId = Insertedcredential.Id;
            db.Add<IUser>(dbUser);
            db.SaveChanges();
            return View("Login");
            }
            else{
                ViewBag.Alert = "Email already exists";
                return View("SignUp");
            }
            
        }
    }
    }
}
