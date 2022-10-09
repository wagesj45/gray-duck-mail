using GrayDuckMail.Common;
using GrayDuckMail.Common.Database;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MimeKit;
using MimeKit.Text;
using NLog;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GrayDuckMail.Web.Worker
{
    /// <summary>
    /// An asyncronous background service that initiates the onboarding process for new contacts.
    /// </summary>
    public class Onboarder : BackgroundService
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        /// <summary>
        /// This method is called when the <see cref="T:Microsoft.Extensions.Hosting.IHostedService" />
        /// starts. This is the main processing thread of the service.
        /// </summary>
        /// <param name="stoppingToken">
        ///     Triggered when
        ///     <see cref="M:Microsoft.Extensions.Hosting.IHostedService.StopAsync(System.Threading.CancellationToken)" />
        ///     is called.
        /// </param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task" /> that represents the long running operations.
        /// </returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.Debug("Establishing database context using {0}", ApplicationSettings.DatabaseFilePath.AbsolutePath);
            var database = new SqliteDatabase(ApplicationSettings.DatabaseFilePath.AbsolutePath);

            logger.Info("Beginning email fetch loop.");
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (var discussionList in database.DiscussionLists)
                {
                    logger.Debug("Processing list {0}", discussionList.Name);

                    var createdSubscriptions = database.ContactSubscriptions
                        .Include(subscription => subscription.Contact)
                        .Where(subscription => subscription.Status == SubscriptionStatus.Created && subscription.DiscussionListID == discussionList.ID);

                    if (createdSubscriptions.Any())
                    {
                        foreach (var subscription in createdSubscriptions)
                        {
                            try
                            {
                                SharedMemory.AddEmail(EmailDefinition.CreateOnboarding(discussionList, subscription.Contact));

                                subscription.Status = SubscriptionStatus.AwaitingConfirmation;
                            }
                            catch (Exception e)
                            {
                                logger.Error(e);
                            }
                        }
                    }
                    else
                    {
                        logger.Debug("No freshly created assignments waiting for onboarding.");
                    }
                }

                database.SaveChanges();

                // End the loop and wait the alloted time.
                logger.Debug("Fetch loop complete. Waiting {0}", DockerEnvironmentVariables.FetchTime);
                await Task.Delay(DockerEnvironmentVariables.FetchTime, stoppingToken);
            }

            logger.Info("Email fetcher shutting down.");
            return;
        }
    }
}
