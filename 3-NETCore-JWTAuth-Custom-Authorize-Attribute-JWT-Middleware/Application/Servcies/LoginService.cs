using Application.Interfaces;
using Application.Models;
using System;
using Microsoft.Extensions.Options;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Application.Servcies
{
    public class LoginService : ILoginService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserService _userSerice;

        public LoginService(IOptions<AppSettings> appSettings, IUserService userSerice)
        {
            _appSettings = appSettings.Value;
            _userSerice = userSerice;
        }

        public TokenModel GetTokenModel(LoginModel loginModel)
        {
            var user = _userSerice.GetUserDetails(loginModel);

            DateTime accessTokenExpirtTime = DateTime.UtcNow.AddDays(1);

            var token = new TokenModel
            {
                AccessToken = GenerateJwtToken(user),
                AccessTokenExpiryTime = accessTokenExpirtTime,
                UserName = user.UserName,
                Name = user.Name,
                EmailId = user.Email
            };

            return token;
        }

        private string GenerateJwtToken(UserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = Encoding.ASCII.GetBytes(_appSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", user.UserId.ToString()),
                    new Claim("userName", user.UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var finaltoken = tokenHandler.WriteToken(token);
            return finaltoken;
        }
    }
}
