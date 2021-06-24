using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TopcoderNetApi.Model;

namespace TopcoderNetApi.Services.Users
{
    class LoginService : ILoginService
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginService"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public LoginService(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Generates the JWT.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public string GenerateJwt(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.FullName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}