using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TopcoderNetApi.DataContext;

namespace TopcoderNetApi.Services.Lessons
{
    class LessonService : ILessonService
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly OnlineCourseDataContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="LessonService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public LessonService(OnlineCourseDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the lesson.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Model.Lesson GetLesson(Guid id)
        {
            var lesson = _context.Lessons.Include(x => x.Section).FirstOrDefault(x => x.Id == id);
            if (lesson == null)
                throw new Exception("The provided lesson does not exist");
            return lesson;
        }
    }
}