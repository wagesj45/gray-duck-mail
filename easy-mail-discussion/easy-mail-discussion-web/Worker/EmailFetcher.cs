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
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.Debug("Establishing database context using {0}", ApplicationSettings.DatabaseFilePath.AbsolutePath);
            var database = new SqliteDatabase(ApplicationSettings.DatabaseFilePath.AbsolutePath);

            logger.Info("Beginning email fetch loop.");
            while (!stoppingToken.IsCancellationRequested)
            {
                var discussionLists = database.DiscussionLists.Include(list => list.Contacts).ThenInclude(list => list.Contact);
                
                foreach (var discussionList in discussionLists)
                {
                    logger.Debug("Processing list {0}", discussionList.Name);

                    using (var client = new Pop3Client())
                    {
                        try
                        {
                            logger.Debug("Connecting to {0}:{1}{2}", discussionList.IncomingMailServer, discussionList.IncomingMailPort, discussionList.UseSSL ? " using SSL" : "");
                            client.Connect(discussionList.IncomingMailServer, discussionList.IncomingMailPort, discussionList.UseSSL, cancellationToken: stoppingToken);

                            logger.Debug("Authenticating as {0}:{1}", discussionList.UserName, new string('*', discussionList.Password.Length));
                            client.Authenticate(discussionList.UserName, discussionList.Password, cancellationToken: stoppingToken);

                            if(client.Count > 0)
                            {
                                logger.Info("Processing {0} messages.", client.Count);

                                var emailMessages = client.GetMessages(0, client.Count, cancellationToken: stoppingToken).Select((emailMessage, index) => new IndexedMimeMessage(index, emailMessage));
                                var filteredSubscribe = FilterMessages(emailMessages, EmailAliasHelper.GetSubscribeAlias(discussionList));
                                var filteredUnsubscribe = FilterMessages(emailMessages, EmailAliasHelper.GetUnsubscribeAlias(discussionList));
                                var filteredRequest = FilterMessages(emailMessages, EmailAliasHelper.GetRequestAlias(discussionList));

                                // Subscription Confirmation Emails
                                var subscriptionConfirmations = await filteredSubscribe;
                                foreach(var subscriptionConfirmation in subscriptionConfirmations)
                                {
                                    var from = subscriptionConfirmation.Sender ?? subscriptionConfirmation.From.Mailboxes.SingleOrDefault();
                                    var contactSubscription = discussionList.Contacts.Where(l => l.Contact.Email.Equals(from.Address, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();

                                    if(!contactSubscription.Contact.Activated)
                                    {
                                        logger.Info("Setting {0} (ID {1}) as active. They have confirmed they control the email address by responding to the subscription confirmation email.", contactSubscription.Contact.Name, contactSubscription.Contact.ID);
                                        contactSubscription.Contact.Activated = true;
                                    }

                                    logger.Info("User {0} subscribing to {1}.", contactSubscription.Contact.Name, discussionList.Name);
                                    contactSubscription.Status = SubscriptionStatus.Subscribed;

                                    logger.Debug("Message {0} (Index {1}) processed. Marked for deletion from the server.", subscriptionConfirmation.MessageId, subscriptionConfirmation.Index);
                                    client.DeleteMessage(subscriptionConfirmation.Index);
                                }

                                // Unsubscribe Confirmation Emails
                                var unsubscribeConfirmations = await filteredUnsubscribe;
                                foreach (var unsubscribeConfirmation in unsubscribeConfirmations)
                                {
                                    var from = unsubscribeConfirmation.Sender ?? unsubscribeConfirmation.From.Mailboxes.SingleOrDefault();
                                    var contactSubscription = discussionList.Contacts.Where(l => l.Contact.Email.Equals(from.Address, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();

                                    logger.Info("User {0} unsubscribing from {1}.", contactSubscription.Contact.Name, discussionList.Name);
                                    contactSubscription.Status = SubscriptionStatus.Unsubscribed;

                                    logger.Debug("Message {0} (Index {1}) processed. Marked for deletion from the server.", subscriptionConfirmation.MessageId, subscriptionConfirmation.Index);
                                    client.DeleteMessage(unsubscribeConfirmation.Index);
                                }

                                // List Assignment Request Emails
                                var requests = await filteredRequest;
                                foreach (var request in requests)
                                {
                                    var from = request.Sender ?? request.From.Mailboxes.SingleOrDefault();
                                    var contactSubscription = discussionList.Contacts.Where(l => l.Contact.Email.Equals(from.Address, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();

                                    if(contactSubscription == null)
                                    {
                                        logger.Info("An unknown user has requested access to {0}. An alert will be sent to the owner address alias.", discussionList);

                                        var newContact = new Contact()
                                        {
                                            Name = from.Name,
                                            Email = from.Address,
                                            Activated = true
                                        };

                                        contactSubscription = new ContactSubscription()
                                        {
                                            Contact = newContact,
                                            DiscussionList = discussionList,
                                            Status = SubscriptionStatus.Requested
                                        };

                                        database.Contacts.Add(newContact);
                                        database.ContactSubscriptions.Add(contactSubscription);
                                    }
                                    else
                                    {
                                        if(contactSubscription.Status != SubscriptionStatus.Denied)
                                        {
                                            logger.Info("{0} has requested access to {1}. Because they have previously be associated with the discussion list, they will be subscribed.", contactSubscription.Contact.Name, discussionList.Name);
                                            contactSubscription.Status = SubscriptionStatus.Subscribed;
                                        }
                                        else
                                        {
                                            logger.Debug("{0} has requested access to {1}, but has previously been denied. Ignoring this request.", contactSubscription.Contact.Name, discussionList.Name);
                                        }
                                    }

                                    logger.Debug("Message {0} (Index {1}) processed. Marked for deletion from the server.", subscriptionConfirmation.MessageId, subscriptionConfirmation.Index);
                                    client.DeleteMessage(request.Index);
                                }

                                // Remaining messages can be assumed to be communications between discussion list members.
                                var discussionMessages = emailMessages.Except(subscriptionConfirmations).Except(unsubscribeConfirmations).Except(requests);
                                foreach (var message in discussionMessages)
                                {
                                    logger.Debug(message.ToString());

                                    logger.Debug("Message {0} (Index {1}) processed. Marked for deletion from the server. (Disabled)", message.MessageId, message.Index);
                                    //client.DeleteMessage(message.Index);
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
        private async Task<IEnumerable<IndexedMimeMessage>> FilterMessages(IEnumerable<IndexedMimeMessage> messages, string emailToAddress)
        {
            return await Task.Run<IEnumerable<IndexedMimeMessage>>(() =>
            {
                var filteredMessages = messages.Where(message => message.GetRecipients(true).Any(recipient => recipient.Address.Equals(emailToAddress, StringComparison.OrdinalIgnoreCase)));

                return filteredMessages.ToArray();
            });
        }
    }
}
