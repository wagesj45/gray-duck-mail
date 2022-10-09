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
    /// An asyncronous background service that sends email queued in the<see cref="SharedMemory.emailQueue"/>.
    /// </summary>
    public class EmailSender : BackgroundService
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        /// <summary>
        /// This method is called when the <see cref="T:Microsoft.Extensions.Hosting.IHostedService" />
        /// starts. This is the main processing thread of the service.
        /// </summary>
        /// <param name="cancellationToken">
        ///     Triggered when
        ///     <see cref="M:Microsoft.Extensions.Hosting.IHostedService.StopAsync(System.Threading.CancellationToken)" />
        ///     is called.
        /// </param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task" /> that represents the long running operations.
        /// </returns>
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            logger.Debug("Establishing database context using {0}", ApplicationSettings.DatabaseFilePath.AbsolutePath);
            var database = new SqliteDatabase(ApplicationSettings.DatabaseFilePath.AbsolutePath);

            logger.Info("Beginning email sender loop.");
            while (!cancellationToken.IsCancellationRequested)
            {
                for (int i = 0; i < DockerEnvironmentVariables.RateLimitPerRoundCount; i++)
                {
                    try
                    {
                        var emailDefinition = SharedMemory.PopEmail();

                        if (emailDefinition != null)
                        {
                            logger.Debug("Found an email definition in the shared memory queue.");

                            switch (emailDefinition.Type)
                            {
                                case EmailDefinitionType.Relay:
                                    using (var smtpClient = new SmtpClient())
                                    {
                                        EmailHelper.RelayEmail(emailDefinition.DiscussionList, emailDefinition.Contact, emailDefinition.Message, database, smtpClient, cancellationToken);
                                        smtpClient.Disconnect(true, cancellationToken);
                                    }
                                    break;
                                case EmailDefinitionType.Onboarding:
                                    using (var smtpClient = new SmtpClient())
                                    {
                                        EmailHelper.SendOnboardingEmail(emailDefinition.DiscussionList, emailDefinition.Contact, smtpClient, cancellationToken);
                                        smtpClient.Disconnect(true, cancellationToken);
                                    }
                                    break;
                                case EmailDefinitionType.RequestOwnerNotification:
                                    using (var smtpClient = new SmtpClient())
                                    {
                                        EmailHelper.SendRequestOwnerNotificationEmail(emailDefinition.DiscussionList, emailDefinition.Contact, smtpClient, cancellationToken);
                                        smtpClient.Disconnect(true, cancellationToken);
                                    }
                                    break;
                                case EmailDefinitionType.SubscriptionConfirmation:
                                    using (var smtpClient = new SmtpClient())
                                    {
                                        EmailHelper.SendSubscriptionConfirmationEmail(emailDefinition.DiscussionList, emailDefinition.Contact, smtpClient, cancellationToken);

                                        smtpClient.Disconnect(true, cancellationToken);
                                    }
                                    break;
                                case EmailDefinitionType.UbsubscriptionConfirmation:
                                    using (var smtpClient = new SmtpClient())
                                    {
                                        EmailHelper.SendUnsubscriptionConfirmationEmail(emailDefinition.DiscussionList, emailDefinition.Contact, smtpClient, cancellationToken);

                                        smtpClient.Disconnect(true, cancellationToken);
                                    }
                                    break;
                                case EmailDefinitionType.Unknown:
                                default:
                                    logger.Error("Recieved a malformed EmailDefinition.");
                                    break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        //We want to catch any potential exception so that the loop can continue in case of failure.
                        logger.Error(e);
                    }
                }

                // End the loop and wait the alloted time.
                logger.Debug("Fetch send complete. Waiting {0}", DockerEnvironmentVariables.RateLimitRoundWaitTime);
                await Task.Delay(DockerEnvironmentVariables.RateLimitRoundWaitTime, cancellationToken);
            }

            logger.Info("Email sender shutting down.");
            return;
        }
    }
}
