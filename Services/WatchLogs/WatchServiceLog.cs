using System.Collections.Generic;
using System.Linq;
using TopcoderNetApi.DataContext;
using TopcoderNetApi.Model;

namespace TopcoderNetApi.Services.WatchLogs
{
    class WatchLogService : IWatchLogService
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly OnlineCourseDataContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="WatchLogService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public WatchLogService(OnlineCourseDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the watch logs.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WatchLog> GetWatchLogs()
        {
            return _context.WatchLogs.ToList();
        }

        /// <summary>
        /// Gets the watch log.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public WatchLog GetWatchLog(int id)
        {
            var log = _context.WatchLogs.FirstOrDefault();
            return log;
        }

        /// <summary>
        /// Adds the watch log.
        /// </summary>
        /// <param name="log">The log.</param>
        public void AddWatchLog(WatchLog log)
        {
            log = new WatchLog
            {
                PercentageWatched = log.PercentageWatched,
                Course = _context.Courses.First(x => x.Id == log.Course.Id),
                Lesson = _context.Lessons.First(x => x.Id == log.Lesson.Id),
                User = _context.Users.First(x => x.Id == log.User.Id)
            };

            _context.WatchLogs.Add(log);
            _context.SaveChanges();
        }
    }
}