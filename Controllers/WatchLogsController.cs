using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopcoderNetApi.Model;
using TopcoderNetApi.Services.Lessons;
using TopcoderNetApi.Services.Users;
using TopcoderNetApi.Services.WatchLogs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TopcoderNetApi.Controllers
{
    [Route("watchLog")]
    [ApiController]
    [Authorize]
    public class WatchLogsController : ControllerBase
    {
        /// <summary>
        ///     The lesson service
        /// </summary>
        private readonly ILessonService _lessonService;

        /// <summary>
        ///     The login service
        /// </summary>
        private readonly ILoginService _loginService;

        /// <summary>
        ///     The context
        /// </summary>
        private readonly IWatchLogService _service;


        /// <summary>
        ///     Initializes a new instance of the <see cref="WatchLogsController" /> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="lessonService">The lesson service.</param>
        /// <param name="loginService">The login service.</param>
        public WatchLogsController(IWatchLogService service, ILessonService lessonService, ILoginService loginService)
        {
            _service = service;
            _lessonService = lessonService;
            _loginService = loginService;
        }

        // GET: api/<WatchLogsController>
        [HttpGet]
        public IEnumerable<WatchLog> Get()
        {
            return _service.GetWatchLogs();
        }

        // GET api/<WatchLogsController>/5
        [HttpGet("{id}")]
        public WatchLog Get(int id)
        {
            var log = _service.GetWatchLog(id);
            return log;
        }

        // POST api/<WatchLogsController>
        [HttpPost]
        public void Post([FromBody] WatchLog value)
        {
            _service.AddWatchLog(value);
        }

        /// <summary>
        ///     Post2s the specified lesson identifier.
        /// </summary>
        /// <param name="lessonId">The lesson identifier.</param>
        /// <param name="pw">The pw.</param>
        [HttpPost("{lessonId}/{pw?}")]
        public void Post(Guid lessonId, int pw)
        {
            var user = _loginService.GetActiveUser();
            var lesson = _lessonService.GetLesson(lessonId);
            if (lesson == null)
                throw new Exception("The provided lesson does no exist");
            _service.CreateRecord(user, lesson, pw);
            _lessonService.Complete(lessonId);
        }
    }
}