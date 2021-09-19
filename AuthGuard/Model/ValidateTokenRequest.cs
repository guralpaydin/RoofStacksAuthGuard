using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthGuard.Model
{
    public class ValidateTokenRequest
    {
        [Required]
        public string ClientId { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
