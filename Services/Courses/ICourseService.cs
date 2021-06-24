using System;
using System.Collections.Generic;
using TopcoderNetApi.Model;

namespace TopcoderNetApi.Services.Courses
{
    public interface ICourseService
    {
        /// <summary>
        /// Gets the courses.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Course> GetCourses();
        
        /// <summary>
        /// Gets the course.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Course GetCourse(Guid id);
        
        /// <summary>
        /// Adds the course.
        /// </summary>
        /// <param name="value">The value.</param>
        void AddCourse(Course value);
    }
}
