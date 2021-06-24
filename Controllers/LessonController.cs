using System;
using Microsoft.AspNetCore.Mvc;
using TopcoderNetApi.Model;
using TopcoderNetApi.Services.Lesson;

namespace TopcoderNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly ILessonService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="LessonController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public LessonController(ILessonService service)
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
