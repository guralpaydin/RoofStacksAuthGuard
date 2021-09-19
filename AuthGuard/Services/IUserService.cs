using AuthGuard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthGuard.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        AuthenticateResponse RefreshToken(string token);
        ValidateTokenResponse ValidateToken(ValidateTokenRequest model);
    }
}
