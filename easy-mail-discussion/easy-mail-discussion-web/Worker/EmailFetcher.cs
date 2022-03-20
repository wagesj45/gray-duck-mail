using EasyMailDiscussion.Common;
using EasyMailDiscussion.Common.Database;
using MailKit.Net.Pop3;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MimeKit;
using MimeKit.Text;
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

        /// <summary>
        /// This method is called when the <see cref="T:Microsoft.Extensions.Hosting.IHostedService" />
        /// starts. The implementation should return a task that represents the lifetime of the long
        /// running operation(s) being performed.
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
                var discussionLists = database.DiscussionLists.Include(list => list.Contacts).ThenInclude(list => list.Contact);

                foreach (var discussionList in discussionLists)
                {
                    logger.Debug("Processing list {0}", discussionList.Name);

                    using (var pop3Client = new Pop3Client())
                    {
                        try
                        {
                            logger.Debug("Connecting to {0}:{1}{2}", discussionList.IncomingMailServer, discussionList.IncomingMailPort, discussionList.UseSSL ? " using SSL" : "");
                            pop3Client.Connect(discussionList.IncomingMailServer, discussionList.IncomingMailPort, discussionList.UseSSL, cancellationToken: stoppingToken);

                            logger.Debug("Authenticating as {0}", discussionList.UserName);
                            pop3Client.Authenticate(discussionList.UserName, discussionList.Password, cancellationToken: stoppingToken);

                            if (pop3Client.Count > 0)
                            {
                                logger.Info("Processing {0} messages.", pop3Client.Count);

                                var emailMessages = pop3Client.GetMessages(0, pop3Client.Count, cancellationToken: stoppingToken).Select((emailMessage, index) => IndexedMimeMessage.IndexMimeMessage(index, emailMessage));
                                var filteredSubscribe = FilterMessages(emailMessages, EmailAliasHelper.GetSubscribeAlias(discussionList));
                                var filteredUnsubscribe = FilterMessages(emailMessages, EmailAliasHelper.GetUnsubscribeAlias(discussionList));
                                var filteredRequest = FilterMessages(emailMessages, EmailAliasHelper.GetRequestAlias(discussionList));

                                // Subscription Confirmation Emails
                                var subscriptionConfirmations = await filteredSubscribe;
                                foreach (var subscriptionConfirmation in subscriptionConfirmations)
                                {
                                    var from = subscriptionConfirmation.Message.Sender ?? subscriptionConfirmation.Message.From.Mailboxes.SingleOrDefault();
                                    var subscription = discussionList.Contacts.Where(l => l.Contact.Email.Equals(from.Address, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();

                                    if (!subscription.Contact.Activated)
                                    {
                                        logger.Info("Setting {0} (ID {1}) as active. They have confirmed they control the email address by responding to the subscription confirmation email.", subscription.Contact.Name, subscription.Contact.ID);
                                        subscription.Contact.Activated = true;
                                    }

                                    logger.Info("User {0} subscribing to {1}.", subscription.Contact.Name, discussionList.Name);
                                    subscription.Status = SubscriptionStatus.Subscribed;

                                    logger.Debug("Message {0} (Index {1}) processed. Marked for deletion from the server.", subscriptionConfirmation.Message.MessageId, subscriptionConfirmation.Index);
                                    pop3Client.DeleteMessage(subscriptionConfirmation.Index);
                                }

                                // Unsubscribe Confirmation Emails
                                var unsubscribeConfirmations = await filteredUnsubscribe;
                                foreach (var unsubscribeConfirmation in unsubscribeConfirmations)
                                {
                                    var from = unsubscribeConfirmation.Message.Sender ?? unsubscribeConfirmation.Message.From.Mailboxes.SingleOrDefault();
                                    var subscription = discussionList.Contacts.Where(l => l.Contact.Email.Equals(from.Address, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();

                                    logger.Info("User {0} unsubscribing from {1}.", subscription.Contact.Name, discussionList.Name);
                                    subscription.Status = SubscriptionStatus.Unsubscribed;

                                    logger.Debug("Message {0} (Index {1}) processed. Marked for deletion from the server.", unsubscribeConfirmation.Message.MessageId, unsubscribeConfirmation.Index);
                                    pop3Client.DeleteMessage(unsubscribeConfirmation.Index);
                                }

                                // List Assignment Request Emails
                                var requests = await filteredRequest;
                                foreach (var request in requests)
                                {
                                    var from = request.Message.Sender ?? request.Message.From.Mailboxes.SingleOrDefault();
                                    var subscription = discussionList.Contacts.Where(l => l.Contact.Email.Equals(from.Address, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();

                                    if (subscription == null)
                                    {
                                        logger.Info("An unknown user has requested access to {0}. An alert will be sent to the owner address alias.", discussionList);

                                        var newContact = new Contact()
                                        {
                                            Name = from.Name,
                                            Email = from.Address,
                                            Activated = true
                                        };

                                        subscription = new ContactSubscription()
                                        {
                                            Contact = newContact,
                                            DiscussionList = discussionList,
                                            Status = SubscriptionStatus.Requested
                                        };

                                        database.Contacts.Add(newContact);
                                        database.ContactSubscriptions.Add(subscription);
                                    }
                                    else
                                    {
                                        if (subscription.Status != SubscriptionStatus.Denied)
                                        {
                                            logger.Info("{0} has requested access to {1}. Because they have previously be associated with the discussion list, they will be subscribed.", subscription.Contact.Name, discussionList.Name);
                                            subscription.Status = SubscriptionStatus.Subscribed;
                                        }
                                        else
                                        {
                                            logger.Debug("{0} has requested access to {1}, but has previously been denied. Ignoring this request.", subscription.Contact.Name, discussionList.Name);
                                        }
                                    }

                                    logger.Debug("Message {0} (Index {1}) processed. Marked for deletion from the server.", request.Message.MessageId, request.Index);
                                    pop3Client.DeleteMessage(request.Index);
                                }

                                // Remaining messages can be assumed to be communications between discussion list members.
                                var discussionMessages = emailMessages.Except(subscriptionConfirmations)
                                    .Except(unsubscribeConfirmations)
                                    .Except(requests);
                                foreach (var discussionMessage in discussionMessages)
                                {
                                     logger.Debug(discussionMessage.ToString());

                                    var from = discussionMessage.Message.Sender ?? discussionMessage.Message.From.Mailboxes.SingleOrDefault();
                                    var subscription = discussionList.Contacts.Where(l => l.Contact.Email.Equals(from.Address, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();

                                    if (subscription != null && EmailHelper.Authorized.Contains(subscription.Status))
                                    {
                                        var parentMessage = database.Messages.Where(message => message.EmailID.Equals(discussionMessage.Message.MessageId) || message.EmailID.Equals(discussionMessage.Message.InReplyTo)).SingleOrDefault();
                                        if(parentMessage == null)
                                        {
                                            parentMessage = database.RelayIdentifiers.Include(relayIdentifier => relayIdentifier.Message)
                                                .Where(relayIdentifier => relayIdentifier.RelayEmailID.Equals(discussionMessage.Message.MessageId) || relayIdentifier.RelayEmailID.Equals(discussionMessage.Message.InReplyTo))
                                                .Select(relayIdentifier => relayIdentifier.Message)
                                                .Distinct()
                                                .SingleOrDefault();
                                        }

                                        var message = new Message()
                                        {
                                            Raw = discussionMessage.Message.ToString(),
                                            BodyRaw = discussionMessage.Message.Body.ToString(),
                                            BodyHTML = discussionMessage.Message.HtmlBody,
                                            BodyText = discussionMessage.Message.TextBody,
                                            DiscussionListID = discussionList.ID,
                                            EmailID = discussionMessage.Message.MessageId,
                                            OriginatorContactID = subscription.ContactID,
                                            Recieved = DateTime.UtcNow,
                                            Subject = discussionMessage.Message.Subject
                                        };

                                        if (parentMessage != null)
                                        {
                                            message.ParentID = parentMessage.ID;
                                        }

                                        using (var smtpClient = new SmtpClient())
                                        {

                                            try
                                            {
                                                var listParticipants = discussionList.Contacts.Where(contact => contact.Status == SubscriptionStatus.Subscribed);
                                                foreach (var participant in listParticipants)
                                                {
                                                    logger.Debug("Relaying message to {0} ({1})", participant.Contact.Name, participant.Contact.Email);

                                                    var relay = new MimeMessage();
                                                    relay.From.Add(new MailboxAddress(discussionList.Name, discussionList.BaseEmailAddress));
                                                    relay.ReplyTo.Add(new MailboxAddress(discussionList.Name, discussionList.BaseEmailAddress));
                                                    relay.To.Add(new MailboxAddress(subscription.Contact.Name, subscription.Contact.Email));
                                                    relay.Subject = string.Format("{0} - Message from {1}", message.Subject.Replace(String.Format("Message from {0}", discussionList.Name),""), discussionList.Name);
                                                    relay.Headers.Add(HeaderId.ListSubscribe, discussionList.ID.ToString());

                                                    if (!string.IsNullOrWhiteSpace(message.BodyHTML))
                                                    {
                                                        logger.Debug("Mesasge body determined to contain HTML.");
                                                        relay.Body = new TextPart(TextFormat.Html)
                                                        {
                                                            Text = message.BodyHTML
                                                        };
                                                    }
                                                    
                                                    if(!string.IsNullOrWhiteSpace(message.BodyText))
                                                    {
                                                        logger.Debug("Message body determined to contain plain text.");
                                                        relay.Body = new TextPart(TextFormat.Text)
                                                        {
                                                            Text = message.BodyText
                                                        };
                                                    }

                                                    var relayIdentifier = new RelayIdentifier()
                                                    {
                                                        Message = message,
                                                        RelayEmailID = relay.MessageId
                                                    };
                                                    database.RelayIdentifiers.Add(relayIdentifier);

                                                    smtpClient.Connect(discussionList.OutgoingMailServer, discussionList.OutgoingMailPort, discussionList.UseSSL, cancellationToken: stoppingToken);

                                                    // Note: only needed if the SMTP server requires authentication
                                                    smtpClient.Authenticate(discussionList.UserName, discussionList.Password, cancellationToken: stoppingToken);

                                                    smtpClient.Send(relay, cancellationToken: stoppingToken);
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                logger.Error(e);
                                            }

                                            smtpClient.Disconnect(true, cancellationToken: stoppingToken);
                                        }
                                    }
                                    else
                                    {
                                        logger.Error("The sender is unrecognized or unauthorized to participate in {0}. We'll log it and let the message be deleted.", discussionList.Name);
                                    }

                                    logger.Debug("Message {0} (Index {1}) processed. Marked for deletion from the server. (Disabled)", discussionMessage.Message.MessageId, discussionMessage.Index);
                                    pop3Client.DeleteMessage(discussionMessage.Index);
                                }
                            }
                            else
                            {
                                logger.Debug("No messages found.");
                            }
                        }
                        catch (Exception e)
                        {
                            logger.Error(e);
                        }

                        pop3Client.Disconnect(true, stoppingToken);
                    }
                }

                if (database.ChangeTracker.HasChanges())
                {
                    logger.Info("Committing changes to database.");
                    database.SaveChanges();
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
                var filteredMessages = messages.Where(message => message.Message.GetRecipients(true).Any(recipient => recipient.Address.Equals(emailToAddress, StringComparison.OrdinalIgnoreCase)));

                return filteredMessages.ToArray();
            });
        }
    }
}
