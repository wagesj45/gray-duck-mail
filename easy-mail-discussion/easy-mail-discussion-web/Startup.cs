using EasyMailDiscussion.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMailDiscussion.Web
{
    /// <summary> Manages the start up routine for the application. </summary>
    public class Startup
    {
        #region Properties

        /// <summary> Gets the configuration interface. </summary>
        /// <value> The configuration interface. </value>
        public IConfiguration Configuration { get; }

        #endregion


        #region Contructors
        
        /// <summary> Constructor. </summary>
        /// <param name="configuration"> The configuration interface. </param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // Read and store globally accessable application settings. This allows values to be able to be read outside of controllers.
            var sectionDatabase = Configuration.GetSection(ApplicationSettings.SECTION_DATABASE);
            var sectionLog = Configuration.GetSection(ApplicationSettings.SECTION_LOG);

            ApplicationSettings.DatabaseFilePath = new Uri(sectionDatabase.GetValue<string>(ApplicationSettings.DATABASE_PATH));
            ApplicationSettings.LogFilePath = new Uri(sectionLog.GetValue<string>(ApplicationSettings.LOG_PATH));


            // Set up the log configuration.
            var logFileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".log";
            var fullLogFile = Path.Combine(ApplicationSettings.LogFilePath.AbsolutePath, logFileName);

            LogManager.Configuration = NLogConfiguration.GetConfiguration(DockerEnvironmentVariables.LogLevel, fullLogFile);
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"> The service collection interface. </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request
        /// pipeline.
        /// </summary>
        /// <param name="app"> The application builder interface. </param>
        /// <param name="env"> The web host environment interface. </param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        } 

        #endregion
    }
}
