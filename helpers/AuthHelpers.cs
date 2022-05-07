using System.IdentityModel.Tokens.Jwt;
namespace JMR.helpers
{
    public class AuthHelpers
    {
        public static string getUserEmail(HttpRequest request){
             string BearerToken = request.Headers["Authorization"];
             var jwtEncodedString = BearerToken.Substring(7);
             var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(jwtEncodedString);
            string r = (string)jsonToken.Payload["email"];
            return r;
        }
    }
}