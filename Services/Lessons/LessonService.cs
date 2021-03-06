using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TopcoderNetApi.DataContext;
using TopcoderNetApi.Model;

namespace TopcoderNetApi.Services.Lessons
{
    internal class LessonService : ILessonService
    {
        /// <summary>
        ///     The context
        /// </summary>
        private readonly OnlineCourseDataContext _context;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LessonService" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public LessonService(OnlineCourseDataContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Gets the lesson.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Lesson GetLesson(Guid id)
        {
            var lesson = _context.Lessons.Include(x => x.Section).ThenInclude(x => x.Course)
                .FirstOrDefault(x => x.Id == id);
            if (lesson == null)
                throw new Exception("The provided lesson does not exist");
            return lesson;
        }

        /// <summary>
        ///     Gets the lessons.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Lesson> GetLessons()
        {
            return _context.Lessons.ToList();
        }

        /// <summary>
        ///     Completes the specified lesson identifier.
        /// </summary>
        /// <param name="lessonId">The lesson identifier.</param>
        public void Complete(Guid lessonId)
        {
            var lesson = _context.Lessons.First(x => x.Id == lessonId);
            lesson.IsCompleted = true;
            _context.SaveChanges();
        }
    }
}