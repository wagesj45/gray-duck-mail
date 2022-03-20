using EasyMailDiscussion.Common;
using EasyMailDiscussion.Common.Database;
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

namespace EasyMailDiscussion.Web.Worker
{
    public class Onboarder : BackgroundService
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

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
                                    message.From.Add(new MailboxAddress(discussionList.Name, discussionList.BaseEmailAddress));
                                    message.ReplyTo.Add(new MailboxAddress(discussionList.Name, EmailAliasHelper.GetSubscribeAlias(discussionList)));
                                    message.To.Add(new MailboxAddress(subscription.Contact.Name, subscription.Contact.Email));
                                    message.Subject = string.Format("Subscribe to {0}", discussionList.Name);
                                    message.Headers.Add(HeaderId.ListSubscribe, discussionList.ID.ToString());

                                    message.Body = new TextPart(TextFormat.Html)
                                    {
                                        Text = EmailHelper.FillMainTemplate(
                                            "Welcome!",
                                            String.Format("You've been invited to the '{0}' Email Discussion List", discussionList.Name),
                                            String.Format("The '{0}' email list administator has invited you to participate. To confirm your subscription, simply reply to this e-mail. If you do not wish to participate, you can ignore this email.", discussionList.Name),
                                            discussionList.Name,
                                            discussionList
                                            )
                                    };

                                    client.Connect(discussionList.OutgoingMailServer, discussionList.OutgoingMailPort, discussionList.UseSSL, cancellationToken: stoppingToken);

                                    // Note: only needed if the SMTP server requires authentication
                                    client.Authenticate(discussionList.UserName, discussionList.Password, cancellationToken: stoppingToken);

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
