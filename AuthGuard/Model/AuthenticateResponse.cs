

using AuthGuard.Entities;
using System.Text.Json.Serialization;

namespace AuthGuard.Model
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string JwtToken { get; set; }

        [JsonIgnore] 
        public string RefreshToken { get; set; }

        public AuthenticateResponse(User user, string jwtToken, string refreshToken)
        {
            Id = user.Id;
            FirstName = user.Name;
            UserName = user.UserName;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}
