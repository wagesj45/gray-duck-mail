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
        /// <summary> The logging conduit. </summary>
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            var logFile = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".log";
            var fullLogPath = Path.Combine("/var/log/easy-email-discussion/", logFile);

            LogManager.Configuration = NLogConfiguration.GetConfiguration("info", fullLogPath);

            CreateHostBuilder(args).Build().Run();
        }

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
    }
}
