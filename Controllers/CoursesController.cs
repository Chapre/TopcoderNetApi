using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TopcoderNetApi.Model;
using TopcoderNetApi.Services.Courses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TopcoderNetApi.Controllers
{
    [Route("course")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly ICourseService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoursesController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public CoursesController(ICourseService service)
        {
            _service = service;
        }
        // GET: api/<CourseController1>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return _service.GetCourses();
        }

        // GET api/<CourseController1>/5
        [HttpGet("{id}")]
        public Course Get(Guid id)
        {
            var course = _service.GetCourse(id);
            return course;
        }

        // POST api/<CourseController1>
        [HttpPost]
        public void Post([FromBody] Course value)
        {
            _service.AddCourse(value);
        }
    }
}
