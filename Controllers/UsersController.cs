﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopcoderNetApi.Model;
using TopcoderNetApi.Services.Users;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TopcoderNetApi.Controllers
{
    [Route("user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly IUSerService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public UsersController(IUSerService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _service.GetUsers();
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public User Get(string id)
        {
            var user= _service.GetUser(id);
            return user;
        }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            _service.AddUser(value);
        }
    }
}