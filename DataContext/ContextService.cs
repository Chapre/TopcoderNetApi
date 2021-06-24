using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TopcoderNetApi.Model;

namespace TopcoderNetApi.DataContext
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TopcoderNetApi.DataContext.IContextService" />
    public class ContextService: IContextService
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="IContextService" /> is initialised.
        /// </summary>
        /// <value>
        ///   <c>true</c> if initialised; otherwise, <c>false</c>.
        /// </value>
        public bool Initialised { get; private set; }   
        
        /// <summary>
        ///     The logger
        /// </summary>
        private readonly ILogger<ContextService> _logger;

        /// <summary>
        ///     The service provider
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextService"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="logger">The logger.</param>
        public ContextService(IServiceProvider serviceProvider, ILogger<ContextService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        /// <summary>
        /// Initialises this instance.
        /// </summary>
        public void Initialise()
        {
            if (Initialised)
                return;
            using var scope = _serviceProvider.CreateScope();
            ApplyContextMigration(scope);
            SeedUsers(scope);
            SeedTestData(scope);
            Initialised = true;
        }

        private void SeedTestData(IServiceScope scope)
        {
            const string rootCourse = "course name";
            const string rootSection = "section name";
            const string rootLesson = "lesson name";
            const string rootWatchLog = "watchlog name";
            var rand = new Random((int) DateTime.Now.Ticks);
            var context = scope.ServiceProvider.GetRequiredService<OnlineCourseDataContext>();
            var root = context.Users.FirstOrDefault(x => x.FullName == "root");
            var course = context.Courses.FirstOrDefault(x => x.Name == rootCourse);
            if (course == null)
            {
                course = new Course() {Name = rootCourse};
                context.Courses.Add(course);
            }

            var section = context.Sections.FirstOrDefault(x => x.Name == rootSection);
            if (section == null)
            {
                section = new Section
                {
                    Name = rootSection,
                    Order = rand.Next(0, 100),
                    Course = course
                };
                context.Sections.Add(section);
            }

            var lesson = context.Lessons.FirstOrDefault(x => x.Name == rootLesson);
            if (lesson == null)
            {
                lesson = new Lesson
                {
                    Name = rootLesson,
                    VideoUrl = new Guid().ToString(),
                    Order = rand.Next(0,100),
                    Section = section
                };
                
                context.Lessons.Add(lesson);
            }



        }

        /// <summary>
        /// Seeds the users.
        /// </summary>
        /// <param name="scope">The scope.</param>
        private void SeedUsers(IServiceScope scope)
        {
            var context = scope.ServiceProvider.GetRequiredService<OnlineCourseDataContext>();
            var root = context.Users.FirstOrDefault(x => x.FullName == "root");
            if (root!=null)
                return;
            root = new User() {FullName = "root", ImageUrl = "root"};
            context.Users.Add(root);
            context.SaveChanges();
        }

        /// <summary>
        /// Applies the context migration.
        /// </summary>
        /// <param name="scope">The scope.</param>
        private void ApplyContextMigration(IServiceScope scope)
        {
            var context = scope.ServiceProvider.GetRequiredService<OnlineCourseDataContext>();
            _logger.LogInformation("Migrating context ....");
            try
            {
                context.Database.Migrate();
                _logger.LogInformation("Migrating context completed!");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Migrating context failed!{Environment.NewLine}{ex?.Message}");
                throw;
            }
            
            
        }
    }
}
