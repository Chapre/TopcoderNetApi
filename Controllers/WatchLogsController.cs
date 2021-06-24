using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TopcoderNetApi.Model;
using TopcoderNetApi.Services.WatchLogs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TopcoderNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchLogsController : ControllerBase
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly IWatchLogService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="WatchLogsController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public WatchLogsController(IWatchLogService service)
        {
            _service = service;
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
    }
}
