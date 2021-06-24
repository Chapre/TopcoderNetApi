using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopcoderNetApi.Model;
using TopcoderNetApi.Services.Lessons;

namespace TopcoderNetApi.Controllers
{
    [Route("lesson")]
    [ApiController]
    [Authorize]
    public class LessonsController : ControllerBase
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly ILessonService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="LessonsController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public LessonsController(ILessonService service)
        {
            _service = service;
        }
        
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Lesson Get(Guid id)
        {
            Lesson lesson = _service.GetLesson(id);
            return lesson;
        }
    }
}
