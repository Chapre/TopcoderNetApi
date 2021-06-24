using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopcoderNetApi.Model;
using TopcoderNetApi.Services.Users;

namespace TopcoderNetApi.Controllers
{
    [Route("login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        ///     The login service
        /// </summary>
        private readonly ILoginService _loginService;

        /// <summary>
        ///     The user service
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LoginController" /> class.
        /// </summary>
        /// <param name="loginService">The login service.</param>
        /// <param name="userService">The user service.</param>
        public LoginController(ILoginService loginService, IUserService userService)
        {
            _loginService = loginService;
            _userService = userService;
        }

        /// <summary>
        /// Logins the specified login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = _userService.GetUserByName(login.Username);
            if (user != null)
            {
                var tokenString = _loginService.GenerateJwt(user);
                response = Ok(new {token = tokenString});
            }

            return response;
        }
    }
}