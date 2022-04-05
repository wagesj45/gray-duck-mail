using EasyMailDiscussion.Common;
using EasyMailDiscussion.Web.Worker;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMailDiscussion.Web
{
    /// <summary> The root program class for the application. </summary>
    public class Program
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Methods

        /// <summary> Main entry-point for this application. </summary>
        /// <param name="args"> An array of command-line argument strings. </param>
        public static void Main(string[] args)
        {
            logger.Info("Starting the main application.");

            CreateHostBuilder(args).Build().Run();
        }

        /// <summary> Creates the host builder configuration interface. </summary>
        /// <param name="args"> An array of command-line argument strings. </param>
        /// <returns> The host builder configuration interface. </returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    //services.AddHostedService<EmailFetcher>();
                    //services.AddHostedService<Onboarder>();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        #endregion
    }
}
