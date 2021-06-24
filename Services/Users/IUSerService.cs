using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopcoderNetApi.Model;

namespace TopcoderNetApi.Services.Users
{
    public interface IUSerService
    {
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        User GetUser(string id);

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetUsers();

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void AddUser(User user);
    }
}
