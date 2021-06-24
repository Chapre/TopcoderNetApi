using System;
using System.Collections.Generic;
using System.Linq;
using TopcoderNetApi.Model;

namespace TopcoderNetApi.Services.Courses
{
    class CourseService : ICourseService
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly OnlineCourseDataContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CourseService(OnlineCourseDataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Gets the courses.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public Course GetCourse(Guid id)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Id == id);
            return course;
        }

        public void AddCourse(Course value)
        {
            var course = new Course()
            {
                Name = value.Name
            };

            _context.Courses.Add(course);
            _context.SaveChanges();
        }
    }
}