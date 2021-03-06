using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopcoderNetApi.Model;
using TopcoderNetApi.Services.Users;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TopcoderNetApi.Controllers
{
    [Route("user")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        /// <summary>
        ///     The service
        /// </summary>
        private readonly IUserService _service;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UsersController" /> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public UsersController(IUserService service)
        {
            _service = service;
        }

        /// <summary>
        ///     Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _service.GetUsers();
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public User Get(string id)
        {
            return _service.GetUser(id);
        }

        /// <summary>
        ///     Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            _service.AddUser(value);
        }
    }
}