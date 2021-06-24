using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TopcoderNetApi.DataContext
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TopcoderNetApi.DataContext.IContextService" />
    public class ContextService: IContextService
    {
        public bool Initialised { get; private set; }        /// <summary>
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
    }
}
