using Microsoft.Extensions.Hosting;
using NLog;
using System;
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
            logger.Info("Beginning email fetch loop.");
            while(!stoppingToken.IsCancellationRequested)
            {
                //do stuff
                
                await Task.Delay(DockerEnvironmentVariables.FetchTime, stoppingToken);
            }

            return;
        }
    }
}
