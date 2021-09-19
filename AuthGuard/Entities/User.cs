using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuthGuard.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }
        [JsonIgnore]
        public string JwtToken { get; set; }
        [JsonIgnore]
        public string ClientSecret { get; set; }
    }
}
