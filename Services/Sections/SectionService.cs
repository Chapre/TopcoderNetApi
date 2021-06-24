using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TopcoderNetApi.DataContext;
using TopcoderNetApi.Model;
using TopcoderNetApi.Services.Lessons;

namespace TopcoderNetApi.Services.Sections
{
    class SectionService : ISectionService
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly OnlineCourseDataContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="LessonService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SectionService(OnlineCourseDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the lesson.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Section GetSection(Guid id)
        {
            var lesson = _context.Sections.Include(x => x.Course).FirstOrDefault(x => x.Id == id);
            if (lesson == null)
                throw new Exception("The provided lesson does not exist");
            return lesson;
        }

        /// <summary>
        /// Gets the sections.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Section> GetSections()
        {
            return _context.Sections.ToList();
        }

        /// <summary>
        /// Adds the setion.
        /// </summary>
        /// <param name="section">The section.</param>
        public void AddSetion(Section section)
        {
            var course = _context.Courses.First(x => x.Id == section.Course.Id);
            section = new Section()
            {
                Name = section.Name,
                Order = section.Order,
                Course = course
            };

            _context.Sections.Add(section);
            _context.SaveChanges();
        }
    }
}