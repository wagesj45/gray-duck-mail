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
    public class Program
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Methods

        /// <summary> Main entry-point for this application. </summary>
        /// <param name="args"> An array of command-line argument strings. </param>
        public static void Main(string[] args)
        {
            var logFile = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".log";
            var fullLogPath = Path.Combine("/var/log/easy-email-discussion/", logFile);

            LogManager.Configuration = NLogConfiguration.GetConfiguration(DockerEnvironmentVariables.LogLevel, fullLogPath);

            CreateHostBuilder(args).Build().Run();
        }

        /// <summary> Creates host builder. </summary>
        /// <param name="args"> An array of command-line argument strings. </param>
        /// <returns> The new host builder. </returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<EmailFetcher>();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }); 

        #endregion
    }
}
