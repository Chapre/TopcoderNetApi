using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TopcoderNetApi.DataContext;
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
        /// The accessor
        /// </summary>
        private readonly IHttpContextAccessor _accessor;

        /// <summary>
        /// The context
        /// </summary>
        private readonly OnlineCourseDataContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginService" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="accessor">The accessor.</param>
        /// <param name="context">The context.</param>
        public LoginService(IConfiguration config, IHttpContextAccessor accessor, OnlineCourseDataContext context)
        {
            _config = config;
            _accessor = accessor;
            _context = context;
        }

        /// <summary>
        /// Gets the active user.
        /// </summary>
        /// <returns></returns>
        public User GetActiveUser()
        {
            if (_accessor?.HttpContext?.User.Identity is ClaimsIdentity identity)
            {
                var id = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return _context.Users.FirstOrDefault(x => x.Id == id);
            }

            return null;
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
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}