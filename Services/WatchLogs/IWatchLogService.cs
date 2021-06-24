using System.Collections.Generic;
using TopcoderNetApi.Model;

namespace TopcoderNetApi.Services.WatchLogs
{
    public interface IWatchLogService
    {
        /// <summary>
        /// Gets the watch logs.
        /// </summary>
        /// <returns></returns>
        IEnumerable<WatchLog> GetWatchLogs();

        /// <summary>
        /// Gets the watch log.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        WatchLog GetWatchLog(int id);

        /// <summary>
        /// Adds the watch log.
        /// </summary>
        /// <param name="value">The value.</param>
        void AddWatchLog(WatchLog value);

        /// <summary>
        /// Creates the record.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="lesson">The lesson.</param>
        /// <param name="pw">The pw.</param>
        void CreateRecord(User user, Lesson lesson, int pw);
    }
}
