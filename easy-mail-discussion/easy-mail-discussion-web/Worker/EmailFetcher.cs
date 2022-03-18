using EasyMailDiscussion.Common;
using EasyMailDiscussion.Common.Database;
using MailKit.Net.Pop3;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MimeKit;
using NLog;
using System;
using System.Collections.Generic;
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
                var discussionLists = database.DiscussionLists.Include(list => list.Contacts).ThenInclude(list => list.Contact);
                
                foreach (var list in discussionLists)
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

                                var messages = client.GetMessages(0, client.Count, cancellationToken: stoppingToken);
                                var subscriptionConfirmations = FilterMessages(messages, EmailAliasHelper.GetSubscribeAlias(list));
                                var unsubscribeConfirmations = FilterMessages(messages, EmailAliasHelper.GetUnsubscribeAlias(list));
                                var requests = FilterMessages(messages, EmailAliasHelper.GetRequestAlias(list));

                                // Subscription Confirmation Emails
                                foreach(var subscriptionConfirmation in await subscriptionConfirmations)
                                {
                                    var from = subscriptionConfirmation.Sender ?? subscriptionConfirmation.From.Mailboxes.SingleOrDefault();
                                    var contactSubscription = list.Contacts.Where(l => l.Contact.Email.Equals(from.Address, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();

                                    if(!contactSubscription.Contact.Activated)
                                    {
                                        contactSubscription.Contact.Activated = true;
                                    }
                                }

                                // Unsubscribe Confirmation Emails
                                foreach(var unsubscribeConfirmation in await unsubscribeConfirmations)
                                {
                                    //
                                }

                                // List Assignment Request Emails
                                foreach (var request in await requests)
                                {
                                    //
                                }
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

                if(database.ChangeTracker.HasChanges())
                {
                    logger.Info("Committing changes to database. (Disabled)");
                    //database.SaveChanges();
                }

                // End the loop and wait the alloted time.
                logger.Debug("Fetch loop complete. Waiting {0}", DockerEnvironmentVariables.FetchTime);
                await Task.Delay(DockerEnvironmentVariables.FetchTime, stoppingToken);
            }

            logger.Info("Email fetcher shutting down.");
            return;
        }

        /// <summary> Filter messages based on the <see cref="MailboxAddress"/> located in <see cref="MimeKit.MimeMessage.To">"TO" addresses</see>. </summary>
        /// <param name="messages">       The messages. </param>
        /// <param name="emailToAddress"> The email to address. </param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process filter messages in this collection.
        /// </returns>
        private async Task<IEnumerable<MimeMessage>> FilterMessages(IEnumerable<MimeMessage> messages, string emailToAddress)
        {
            return await Task.Run<IEnumerable<MimeMessage>>(() =>
            {
                var filteredMessages = messages.Where(message => message.GetRecipients(true).Any(recipient => recipient.Address.Equals(emailToAddress, StringComparison.OrdinalIgnoreCase)));

                return filteredMessages.ToArray();
            });
        }
    }
}
