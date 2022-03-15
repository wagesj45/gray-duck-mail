using CommandLine;
using EasyMailDiscussion.Common;
using NLog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EasyMailDiscussion.Cli
{
    internal class Program
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary> True if application shutdown is requested. </summary>
        private static volatile bool exitRequested = false;

        #endregion

        /// <summary> Main entry-point for this application. </summary>
        /// <param name="args"> An array of command-line argument strings. </param>
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(options =>
            {
                LogManager.Configuration = NLogConfiguration.GetConfiguration(options.LogLevel, options.LogPath.AbsolutePath);

                logger.Debug("Command line options:");
                logger.Debug("Log Level - {0}", options.LogLevel);
                logger.Debug("Database Path - {0}", options.DBPath);
                logger.Debug("Log File Path - {0}", options.LogPath);
                logger.Debug("Email Fetch Time - {0}", options.EmailFetchTime);
            }).WithNotParsed<Options>(errors =>
            {
                foreach (var error in errors)
                {
                    logger.Error(error);
                }
            });
        }

        private static async void RunService(TimeSpan fetchTime)
        {
            
        }
    }
}
