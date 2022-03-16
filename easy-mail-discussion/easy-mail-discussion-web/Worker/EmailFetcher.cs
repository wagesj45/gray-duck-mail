using EasyMailDiscussion.Common.Database;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EasyMailDiscussion.Web.Worker
{
    public class EmailFetcher : BackgroundService
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.Debug("Establishing database context using {0}", ApplicationSettings.DatabaseFilePath.AbsolutePath);
            var database = new SqliteDatabase(ApplicationSettings.DatabaseFilePath.AbsolutePath);

            logger.Info("Beginning email fetch loop.");
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach(var list in database.DiscussionLists)
                {
                    logger.Debug("Processing list {0}", list.Name);
                }

                // End the loop and wait the alloted time.
                await Task.Delay(DockerEnvironmentVariables.FetchTime, stoppingToken);
            }

            return;
        }
    }
}
