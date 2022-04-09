using GrayDuckMail.Common;
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
using System.Reflection;
using System.Threading.Tasks;

namespace GrayDuckMail.Web
{
    /// <summary> Manages the start up routine for the application. </summary>
    public class Startup
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

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

            ConfigureNLog(sectionDatabase, sectionLog);

            ConfigureDatabase();
        }

        /// <summary>
        /// Replaces the existing database file with an imported database file, if one exists.
        /// </summary>
        /// <seealso cref="Controllers.AdminController.ImportDatabase(Models.Forms.ImportDatabaseForm)"/>
        /// <seealso cref="Common.Database.SqliteDatabase.ImportedDatabaseFilePath"/>
        private static void ConfigureDatabase()
        {
            // Replace the database, if it exists, with an imported database, if it exists.
            var databaseDirectory = Path.GetDirectoryName(ApplicationSettings.DatabaseFilePath.AbsolutePath);
            var importedDatabases = Directory.GetFiles(databaseDirectory)
                .Where(path => path.EndsWith(Common.Database.SqliteDatabase.TEMP_DATABASE_FILE_EXTENSION));

            // Technically this could be multiple files if they're somehow injected into the 
            foreach (var file in importedDatabases)
            {
                logger.Info("Importing exisiting database {0}", file);

                // If the original database still exists, remove it.
                if (File.Exists(ApplicationSettings.DatabaseFilePath.AbsolutePath))
                {
                    // Delete the old file.
                    File.Delete(ApplicationSettings.DatabaseFilePath.AbsolutePath);
                }

                File.Move(file, ApplicationSettings.DatabaseFilePath.AbsolutePath);
            }
        }

        /// <summary> Configures NLog for this application. </summary>
        /// <param name="sectionDatabase"> The database section of the <c>appsettings.json</c> file. </param>
        /// <param name="sectionLog">      The log section of the <c>appsettings.json</c> file. </param>
        private static void ConfigureNLog(IConfigurationSection sectionDatabase, IConfigurationSection sectionLog)
        {
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
        /// <param name="app">      The application builder interface. </param>
        /// <param name="env">      The web host environment interface. </param>
        /// <param name="lifetime"> The application lifetime management interface. </param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
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

            lifetime.ApplicationStarted.Register(() =>
            {
                logger.Info("Running application.");
            });

            lifetime.ApplicationStopping.Register(() =>
            {
                logger.Info("Stopping the application.");
            });

            lifetime.ApplicationStopped.Register(() =>
            {
                logger.Info("Application stopped.");
            });
        }

        #endregion
    }
}