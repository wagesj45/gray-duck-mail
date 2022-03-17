using EasyMailDiscussion.Common.Database;
using MailKit.Net.Pop3;
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

                    using (var client = new Pop3Client())
                    {
                        try
                        {
                            logger.Debug("Connecting to {0}:{1}{2}", list.IncomingMailServer, list.IncomingMailPort, list.UseSSL ? " using SSL" : "");
                            client.Connect(list.IncomingMailServer, list.IncomingMailPort, list.UseSSL, cancellationToken: stoppingToken);

                            logger.Debug("Authenticating as {0}:{1}", list.UserName, new string('*', list.Password.Length));
                            client.Authenticate(list.UserName, list.Password, cancellationToken: stoppingToken);

                            if(client.Count > 0)
                            {
                                logger.Info("Processing {0} messages.", client.Count);
                                // process.
                            }
                            else
                            {
                                logger.Debug("No messages found.");
                            }
                        }
                        catch(Exception e)
                        {
                            logger.Error(e);
                        }
                    }
                }

                // End the loop and wait the alloted time.
                logger.Debug("Fetch loop complete. Waiting {0}", DockerEnvironmentVariables.FetchTime);
                await Task.Delay(DockerEnvironmentVariables.FetchTime, stoppingToken);
            }

            logger.Info("Email fetcher shutting down.");
            return;
        }
    }
}
