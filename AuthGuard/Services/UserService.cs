using AuthGuard.Entities;
using AuthGuard.Helpers;
using AuthGuard.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthGuard.Services
{
    public class UserService : IUserService
    {
        private DataContext context;

        public UserService(
            DataContext context)
        {
            this.context = context;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = context.Users.SingleOrDefault(x => x.UserName == model.Username && x.Password == model.Password && x.ClientSecret == model.ClientSecret);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt and refresh tokens
            var jwtToken = generateJwtToken(user);
            var refreshToken = generateRefreshToken();

            // save refresh token
            user.RefreshTokens.Add(refreshToken);
            user.JwtToken = jwtToken;
            context.Update(user);
            context.SaveChanges();

            return new AuthenticateResponse(user, jwtToken, refreshToken.Token);
        }

        public AuthenticateResponse RefreshToken(string token)
        {
            var user = context.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));
            if (user == null) return null;
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);
            if (!refreshToken.IsActive) return null;
            var newRefreshToken = generateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            context.Update(user);
            context.SaveChanges();
            var jwtToken = generateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken, newRefreshToken.Token);
        }

        public ValidateTokenResponse ValidateToken(ValidateTokenRequest model)
        {
            var user = context.Users.SingleOrDefault(u => u.Id.ToString() == model.ClientId && u.JwtToken == model.Token);
            if (user == null) return null;

            var isActive = user.RefreshTokens.Any(t => t.IsActive);
            if (!isActive) return null;

            return new ValidateTokenResponse(true);
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(user.ClientSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private RefreshToken generateRefreshToken()
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    ExpireTime = DateTime.UtcNow.AddDays(7)
                };
            }
        }
    }
}
