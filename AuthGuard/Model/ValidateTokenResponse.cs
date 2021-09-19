using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthGuard.Model
{
    public class ValidateTokenResponse
    {
        public bool IsValid { get; set; }

        public ValidateTokenResponse(bool isValid)
        {
            IsValid = isValid;
        }
    }
}
