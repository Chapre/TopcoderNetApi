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
            SeedRootUser(scope);
            SeedTestData(scope);  // comment to skip seeding root test data
            Initialised = true;
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

        /// <summary>
        /// Seeds the users.
        /// </summary>
        /// <param name="scope">The scope.</param>
        private void SeedRootUser(IServiceScope scope)
        {
            var context = scope.ServiceProvider.GetRequiredService<OnlineCourseDataContext>();
            var root = context.Users.FirstOrDefault(x => x.FullName == "root");
            if (root != null)
                return;
            root = new User() { FullName = "root", ImageUrl = "root" };
            context.Users.Add(root);
            context.SaveChanges();
        }

        /// <summary>
        /// Seeds the test data.
        /// </summary>
        /// <param name="scope">The scope.</param>
        private void SeedTestData(IServiceScope scope)
        {
            var rand = new Random((int)DateTime.Now.Ticks);
            var context = scope.ServiceProvider.GetRequiredService<OnlineCourseDataContext>();
            
            const string rootName = "root";
            var root = context.Users.FirstOrDefault(x => x.FullName == rootName);

            const string rootCourse = "root course";
            var course = context.Courses.FirstOrDefault(x => x.Name == rootCourse);
            if (course == null)
            {
                course = new Course() { Name = rootCourse };
                context.Courses.Add(course);
            }

            const string rootSection = "root section";
            var section = context.Sections.FirstOrDefault(x => x.Name == rootSection);
            if (section == null)
            {
                section = new Section {Name = rootSection, Order = rand.Next(0, 100), Course = course};
                context.Sections.Add(section);
            }

            const string rootLesson = "root lesson";
            var lesson = context.Lessons.FirstOrDefault(x => x.Name == rootLesson);
            if (lesson == null)
            {
                lesson = new Lesson
                {
                    Name = rootLesson, VideoUrl = new Guid().ToString(), Order = rand.Next(0, 100),
                    Section = section
                };
                context.Lessons.Add(lesson);
            }

            var watchLog = context.WatchLogs.FirstOrDefault(x => x.User.Id == root.Id);
            if (watchLog == null)
            {
                watchLog = new WatchLog
                    {Course = course, Lesson = lesson, User = root, PercentageWatched = rand.Next(0, 101)};
                context.WatchLogs.Add(watchLog);
            }

            if (!context.ChangeTracker.HasChanges())
                return;
            context.SaveChanges();
        }
    }
}
