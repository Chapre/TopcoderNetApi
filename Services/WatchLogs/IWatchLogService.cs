using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
