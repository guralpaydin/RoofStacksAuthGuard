using System.ComponentModel.DataAnnotations;

namespace AuthGuard.Model
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string ClientSecret { get; set; }
    }
}
