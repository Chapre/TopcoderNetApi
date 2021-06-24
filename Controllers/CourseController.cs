using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopcoderNetApi.Model;
using TopcoderNetApi.Services.Courses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TopcoderNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly ICourseService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public CourseController(ICourseService service)
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

        // PUT api/<CourseController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CourseController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
