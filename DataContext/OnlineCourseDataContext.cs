using Microsoft.EntityFrameworkCore;
using TopcoderNetApi.Model;

namespace TopcoderNetApi
{
    public class OnlineCourseDataContext: DbContext
    {
        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        /// <value>
        /// The courses.
        /// </value>
        public DbSet<Course> Courses { get; set; }

        /// <summary>
        /// Gets or sets the sections.
        /// </summary>
        /// <value>
        /// The sections.
        /// </value>
        public DbSet<Section> Sections { get; set; }

        /// <summary>
        /// Gets or sets the lessons.
        /// </summary>
        /// <value>
        /// The lessons.
        /// </value>
        public DbSet<Lesson> Lessons { get; set; }

        /// <summary>
        /// Gets or sets the watch logs.
        /// </summary>
        /// <value>
        /// The watch logs.
        /// </value>
        public DbSet<Course> WatchLogs { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public DbSet<Section> Users { get; set; }
    }
}
