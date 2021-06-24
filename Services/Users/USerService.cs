using System.Collections.Generic;
using System.Linq;
using TopcoderNetApi.DataContext;
using TopcoderNetApi.Model;

namespace TopcoderNetApi.Services.Users
{
    class USerService : IUserService
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly OnlineCourseDataContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="USerService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public USerService(OnlineCourseDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public User GetUser(string id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void AddUser(User user)
        {
            user = new User
            {
                FullName = user.FullName,
                ImageUrl = user.ImageUrl
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the name of the user by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public User GetUserByName(string name)
        {
            return _context.Users.FirstOrDefault(x => x.FullName == name);
        }
    }
}