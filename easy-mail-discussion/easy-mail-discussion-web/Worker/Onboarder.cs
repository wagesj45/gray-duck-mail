using EasyMailDiscussion.Common;
using EasyMailDiscussion.Common.Database;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MimeKit;
using NLog;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EasyMailDiscussion.Web.Worker
{
    public class Onboarder : BackgroundService
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
                foreach (var list in database.DiscussionLists)
                {
                    logger.Debug("Processing list {0}", list.Name);

                    var createdSubscriptions = database.ContactSubscriptions.Include(subscription => subscription.Contact).Where(subscription => subscription.Status == SubscriptionStatus.Created);

                    if (createdSubscriptions.Any())
                    {
                        foreach (var subscription in createdSubscriptions)
                        {
                            using (var client = new SmtpClient())
                            {
                                try
                                {
                                    var message = new MimeMessage();
                                    message.From.Add(new MailboxAddress(list.Name, list.BaseEmailAddress));
                                    message.ReplyTo.Add(new MailboxAddress(list.Name, EmailAliasHelper.GetSubscribeAlias(list)));
                                    message.To.Add(new MailboxAddress(subscription.Contact.Name, subscription.Contact.Email));
                                    message.Subject = string.Format("Subscribe to {0}", list.Name);
                                    message.Headers.Add(HeaderId.ListSubscribe, list.ID.ToString());

                                    message.Body = new TextPart("plain")
                                    {
                                        Text = string.Format("You been subscribed to {0}. That ok? Simply reply to this email to subscribe to the discussion list.", list.Name)
                                    };

                                    client.Connect(list.OutgoingMailServer, list.OutgoingMailPort, list.UseSSL, cancellationToken: stoppingToken);

                                    // Note: only needed if the SMTP server requires authentication
                                    client.Authenticate(list.UserName, list.Password, cancellationToken: stoppingToken);

                                    client.Send(message, cancellationToken: stoppingToken);
                                    client.Disconnect(true, cancellationToken: stoppingToken);

                                    subscription.Status = SubscriptionStatus.Inactive;
                                }
                                catch (Exception e)
                                {
                                    logger.Error(e);
                                }
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
