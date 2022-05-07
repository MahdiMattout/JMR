using System.IdentityModel.Tokens.Jwt;
namespace JMR.helpers
{
    public class AuthHelpers
    {
        public static string getUserEmail(HttpContext context){ //Just pass Httpcontext in the controller
            string jwtEncodedString = context.Session.GetString("Token");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(jwtEncodedString);
            string email = (string)jsonToken.Payload["email"];
            return email;
        }

        public static int getUserId(HttpContext context){ //Just pass Httpcontext in the controller
            string jwtEncodedString = context.Session.GetString("Token");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(jwtEncodedString);
            int id = (int)(long)jsonToken.Payload["UserId"];
            return id;
        }
    }
}