using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.EntityFrameworkCore;
using TopcoderNetApi.DataContext;
using TopcoderNetApi.Services.Courses;
using TopcoderNetApi.Services.Lessons;
using TopcoderNetApi.Services.Sections;
using TopcoderNetApi.Services.Users;
using TopcoderNetApi.Services.WatchLogs;

namespace TopcoderNetApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabaseContext(services);
            services.AddControllers();
            services.AddSingleton<IContextService, ContextService>();
            services.AddTransient<ILessonService, LessonService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ISectionService, SectionService>();
            services.AddTransient<IWatchLogService, WatchLogService>();
            services.AddTransient<IUSerService, USerService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TopcoderNetApi", Version = "v1" });
            });
        }

        /// <summary>
        ///     Configures the database context.
        /// </summary>
        /// <param name="services">The services.</param>
        private void ConfigureDatabaseContext(IServiceCollection services)
        {
            services.AddDbContext<OnlineCourseDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("OnlineCourseDatabase"),
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30),
                            null);
                    }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IContextService onlineDb)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TopcoderNetApi v1"));
            }

            onlineDb.Initialise();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
