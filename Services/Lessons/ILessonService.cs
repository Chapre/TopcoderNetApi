using System;
using TopcoderNetApi.Model;

namespace TopcoderNetApi.Services.Lessons
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILessonService
    {
        /// <summary>
        /// Gets the lesson.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Lesson GetLesson(Guid id);
    }
}
