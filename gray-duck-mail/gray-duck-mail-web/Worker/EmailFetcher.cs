using GrayDuckMail.Common;
using GrayDuckMail.Common.Database;
using MailKit.Net.Pop3;
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

namespace GrayDuckMail.Web.Worker
{
    /// <summary>
    /// An asyncronous background service that retrieves email messages and processes them.
    /// </summary>
    public class EmailFetcher : BackgroundService
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Methods

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
            logger.Info("Beginning email fetch loop.");

            logger.Debug("Establishing database context using {0}", ApplicationSettings.DatabaseFilePath.AbsolutePath);
            var database = new SqliteDatabase(ApplicationSettings.DatabaseFilePath.AbsolutePath);

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var discussionLists = database.DiscussionLists.Include(list => list.Subscriptions).ThenInclude(list => list.Contact);

                    foreach (var discussionList in discussionLists)
                    {
                        logger.Debug("Processing list {0}", discussionList.Name);

                        using (var client = new EmailClientWrapper(DockerEnvironmentVariables.EmailProtocol, DockerEnvironmentVariables.IMAPFolder))
                        {
                            try
                            {
                                logger.Debug("Connecting to {0}:{1}{2}", discussionList.IncomingMailServer, discussionList.IncomingMailPort, discussionList.UseSSL ? " using SSL" : "");
                                client.Connect(discussionList.IncomingMailServer, discussionList.IncomingMailPort, discussionList.UseSSL, cancellationToken: cancellationToken);

                                logger.Debug("Authenticating as {0}", discussionList.UserName);
                                client.Authenticate(discussionList.UserName, discussionList.Password, cancellationToken: cancellationToken);

                                var emailMessages = client.GetMessages(cancellationToken).Select((emailMessage, index) => IndexedMimeMessage.IndexMimeMessage(index, emailMessage));
                                
                                if (emailMessages.Any())
                                {
                                    logger.Info("Processing {0} messages.", emailMessages.Count());

                                    var filteredSubscribe = FilterMessages(emailMessages, EmailAliasHelper.GetSubscribeAlias(discussionList));
                                    var filteredUnsubscribe = FilterMessages(emailMessages, EmailAliasHelper.GetUnsubscribeAlias(discussionList));
                                    var filteredRequest = FilterMessages(emailMessages, EmailAliasHelper.GetRequestAlias(discussionList));
                                    var filteredBouncedToBounceAlias = FilterMessages(emailMessages, EmailAliasHelper.GetBounceAlias(discussionList));
                                    var filteredBouncedToBaseAddress = FilterBouncedMessages(emailMessages);
                                    var filteredBounced = filteredBouncedToBounceAlias.Concat(filteredBouncedToBaseAddress);

                                    // Subscription Confirmation Emails
                                    foreach (var subscriptionConfirmation in filteredSubscribe)
                                    {
                                        ProcessSubscriptionConfirmations(discussionList, database, client, subscriptionConfirmation, cancellationToken);
                                    }

                                    // Unsubscribe Confirmation Emails
                                    foreach (var unsubscribeConfirmation in filteredUnsubscribe)
                                    {
                                        ProcessUnsubscribeConfirmations(discussionList, database, client, unsubscribeConfirmation);
                                    }

                                    // List Assignment Request Emails
                                    foreach (var request in filteredRequest)
                                    {
                                        ProcessRequests(discussionList, database, client, request, cancellationToken);
                                    }

                                    // Bounced email messages.
                                    foreach (var bounce in filteredBounced)
                                    {
                                        ProcessBounces(discussionList, database, client, bounce);
                                    }

                                    // Remaining messages can be assumed to be communications between discussion list members.
                                    var discussionMessages = emailMessages
                                        .Except(filteredSubscribe)
                                        .Except(filteredUnsubscribe)
                                        .Except(filteredRequest)
                                        .Except(filteredBounced);
                                    foreach (var discussionMessage in discussionMessages)
                                    {
                                        ProcessDiscussionMessages(discussionList, discussionMessage, database, client, cancellationToken);
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

                            client.Disconnect(true, cancellationToken);
                        }
                    }

                    if (database.ChangeTracker.HasChanges())
                    {
                        logger.Info("Committing changes to database.");
                        database.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    //We want to catch any potential exception so that the loop can continue in case of failure.
                    logger.Error(e);
                }

                // End the loop and wait the alloted time.
                logger.Debug("Fetch loop complete. Waiting {0}", DockerEnvironmentVariables.FetchTime);
                await Task.Delay(DockerEnvironmentVariables.FetchTime, cancellationToken);
            }

            logger.Info("Email fetcher shutting down.");
            return;
        }

        /// <summary>
        /// Process the subscription confirmations for the <paramref name="discussionList">discussion
        /// list</paramref>.
        /// </summary>
        /// <param name="discussionList">           Discussion List database object. </param>
        /// <param name="database">                 The database. </param>
        /// <param name="client">               The email client. </param>
        /// <param name="subscriptionConfirmation"> The subscription confirmation. </param>
        /// <param name="cancellationToken">
        ///     (Optional) A token that allows processing to be cancelled.
        /// </param>
        private static void ProcessSubscriptionConfirmations(DiscussionList discussionList, SqliteDatabase database, EmailClientWrapper client, IndexedMimeMessage subscriptionConfirmation, CancellationToken cancellationToken = default)
        {
            var from = subscriptionConfirmation.Message.Sender ?? subscriptionConfirmation.Message.From.Mailboxes.SingleOrDefault();
            var subscription = database.DiscussionLists.Where(_discussionList => _discussionList.ID == discussionList.ID)
                .SelectMany(_discussionList => _discussionList.Subscriptions)
                .Where(subscription => subscription.Contact.Email == from.Address)
                .SingleOrDefault();

            logger.Info("Processing subscription message from {0}.", subscription.Contact.Name);

            if (!subscription.Contact.Activated)
            {
                logger.Info("Setting {0} (ID {1}) as active. They have confirmed they control the email address by responding to the subscription confirmation email.", subscription.Contact.Name, subscription.Contact.ID);
                subscription.Contact.Activated = true;
            }

            logger.Info("User {0} subscribing to {1}.", subscription.Contact.Name, discussionList.Name);
            subscription.Status = SubscriptionStatus.Subscribed;

            SharedMemory.AddEmail(EmailDefinition.CreateSubscriptionConfirmation(discussionList, subscription.Contact));

            logger.Debug("Message {0} (Index {1}) processed. Marked for deletion from the server.", subscriptionConfirmation.Message.MessageId, subscriptionConfirmation.Index);
            client.DeleteMessage(subscriptionConfirmation.Index, cancellationToken);
        }

        /// <summary>
        /// Process the unsubscribe confirmations for the <paramref name="discussionList">discussion
        /// list</paramref>.
        /// </summary>
        /// <param name="discussionList">          Discussion List database object. </param>
        /// <param name="database">                The database. </param>
        /// <param name="client">              The email client. </param>
        /// <param name="unsubscribeConfirmation"> The unsubscribe confirmation. </param>
        private static void ProcessUnsubscribeConfirmations(DiscussionList discussionList, SqliteDatabase database, EmailClientWrapper client, IndexedMimeMessage unsubscribeConfirmation)
        {
            var from = unsubscribeConfirmation.Message.Sender ?? unsubscribeConfirmation.Message.From.Mailboxes.SingleOrDefault();
            var subscription = database.DiscussionLists.Where(_discussionList => _discussionList.ID == discussionList.ID)
                .SelectMany(_discussionList => _discussionList.Subscriptions)
                .Where(subscription => subscription.Contact.Email == from.Address)
                .SingleOrDefault();

            logger.Info("User {0} unsubscribing from {1}.", subscription.Contact.Name, discussionList.Name);
            subscription.Status = SubscriptionStatus.Unsubscribed;

            SharedMemory.AddEmail(EmailDefinition.CreateUnsubscriptionConfirmation(discussionList, subscription.Contact));

            logger.Debug("Message {0} (Index {1}) processed. Marked for deletion from the server. (Disabled)", unsubscribeConfirmation.Message.MessageId, unsubscribeConfirmation.Index);
            client.DeleteMessage(unsubscribeConfirmation.Index);
        }

        /// <summary>
        /// Process the requests to join a the <paramref name="discussionList">discussion list</paramref>.
        /// </summary>
        /// <param name="discussionList">    Discussion List database object. </param>
        /// <param name="database">          The database. </param>
        /// <param name="client">            The email client. </param>
        /// <param name="request">           The request message. </param>
        /// <param name="cancellationToken">
        ///     (Optional) A token that allows processing to be cancelled.
        /// </param>
        private static void ProcessRequests(DiscussionList discussionList, SqliteDatabase database, EmailClientWrapper client, IndexedMimeMessage request, CancellationToken cancellationToken = default)
        {
            var from = request.Message.Sender ?? request.Message.From.Mailboxes.SingleOrDefault();
            var subscription = database.DiscussionLists.Where(_discussionList => _discussionList.ID == discussionList.ID)
                .SelectMany(_discussionList => _discussionList.Subscriptions)
                .Include(subscription => subscription.Contact)
                .Where(subscription => subscription.Contact.Email == from.Address)
                .SingleOrDefault();

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

                SharedMemory.AddEmail(EmailDefinition.CreateOwnerNotification(discussionList, newContact));
            }
            else
            {
                if (subscription.Status == SubscriptionStatus.Subscribed)
                {
                    logger.Error("{0}, who is already subscribed to {1}, has requested access again. Ignoring this message.", subscription.Contact.Name, discussionList.Name);
                }
                else if (subscription.Status != SubscriptionStatus.Denied)
                {
                    logger.Info("{0} has requested access to {1}. Because they have previously be associated with the discussion list, they will be subscribed.", subscription.Contact.Name, discussionList.Name);
                    subscription.Status = SubscriptionStatus.Subscribed;

                    SharedMemory.AddEmail(EmailDefinition.CreateSubscriptionConfirmation(discussionList, subscription.Contact));
                }
                else
                {
                    logger.Debug("{0} has requested access to {1}, but has previously been denied. Ignoring this request.", subscription.Contact.Name, discussionList.Name);
                }
            }

            logger.Debug("Message {0} (Index {1}) processed. Marked for deletion from the server.", request.Message.MessageId, request.Index);
            client.DeleteMessage(request.Index, cancellationToken);
        }

        /// <summary> Process the bounced messages recieved from a contact. </summary>
        /// <param name="discussionList"> Discussion List database object. </param>
        /// <param name="database">       The database. </param>
        /// <param name="client">     The email client. </param>
        /// <param name="bounce">         The bounced message. </param>
        private static void ProcessBounces(DiscussionList discussionList, SqliteDatabase database, EmailClientWrapper client, IndexedMimeMessage bounce)
        {
            var bouncedFrom = bounce.Message.Sender ?? bounce.Message.From.Mailboxes.SingleOrDefault();
            var bouncedOriginallyTo = EmailHelper.GetBouncedMessageRecipient(bounce);
            var subscription = database.DiscussionLists.Where(_discussionList => _discussionList.ID == discussionList.ID)
                .SelectMany(_discussionList => _discussionList.Subscriptions)
                .Where(subscription => subscription.Contact.Email == bouncedFrom.Address || subscription.Contact.Email == bouncedOriginallyTo)
                .SingleOrDefault();

            if (subscription != null)
            {
                logger.Info("The email address for {0} appears to no longer be active.", subscription.Contact.Name);
                subscription.Status = SubscriptionStatus.Bounced;
                subscription.Contact.Activated = false;
            }
            else
            {
                logger.Error("A bounced email was recieved for an address that is not subscribed to {0}. Ignoring this message.", discussionList.Name);
            }

            logger.Debug("Message {0} (Index {1}) processed. Marked for deletion from the server.", bounce.Message.MessageId, bounce.Index);
            client.DeleteMessage(bounce.Index);
        }

        /// <summary>
        /// Process the non-command messages by relaying them to all subscribed members of the
        /// <paramref name="discussionList">discussion list</paramref>.
        /// </summary>
        /// <param name="discussionList">    Discussion List database object. </param>
        /// <param name="discussionMessage"> Message describing the discussion. </param>
        /// <param name="database">          The database. </param>
        /// <param name="client">        The email client. </param>
        /// <param name="cancellationToken">
        ///     Triggered when
        ///     <see cref="M:Microsoft.Extensions.Hosting.IHostedService.StopAsync(System.Threading.CancellationToken)" />
        ///     is called.
        /// </param>
        private static void ProcessDiscussionMessages(DiscussionList discussionList, IndexedMimeMessage discussionMessage, SqliteDatabase database, EmailClientWrapper client, CancellationToken cancellationToken = default)
        {
            logger.Debug(discussionMessage.ToString());

            var from = discussionMessage.Message.Sender ?? discussionMessage.Message.From.Mailboxes.SingleOrDefault();
            var originatorSubscription = discussionList.Subscriptions
                .Where(subscription => subscription.Contact.Email.Equals(from.Address, StringComparison.OrdinalIgnoreCase))
                .SingleOrDefault();

            if (originatorSubscription != null && EmailHelper.ContactAuthorizedStatuses.Contains(originatorSubscription.Status))
            {
                var parentMessage = database.Messages.Where(message => message.EmailID.Equals(discussionMessage.Message.MessageId) || message.EmailID.Equals(discussionMessage.Message.InReplyTo)).SingleOrDefault();
                if (parentMessage == null)
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
                    OriginatorContactID = originatorSubscription.ContactID,
                    Recieved = DateTime.UtcNow,
                    Subject = discussionMessage.Message.Subject
                };

                if (parentMessage != null)
                {
                    message.ParentID = parentMessage.ID;
                }
                
                var listParticipants = discussionList.Subscriptions
                        .Where(subscription => subscription.Status == SubscriptionStatus.Subscribed)
                        .Where(subscription => subscription.ContactID != originatorSubscription.ContactID);

                foreach (var participant in listParticipants)
                {
                    SharedMemory.AddEmail(EmailDefinition.CreateRelay(discussionList, participant.Contact, message));
                }
            }
            else
            {
                logger.Error("The sender is unrecognized or unauthorized to participate in {0}. We'll log it and let the message be deleted.", discussionList.Name);
                logger.Error("From: {0} ({1})", from.Name, from.Address);
                logger.Error("Encoding: {0}", from.Encoding.EncodingName);
                foreach (var domain in from.Route)
                {
                    logger.Error("-- {0}", domain);
                }
            }

            logger.Debug("Message {0} (Index {1}) processed. Marked for deletion from the server.", discussionMessage.Message.MessageId, discussionMessage.Index);
            client.DeleteMessage(discussionMessage.Index, cancellationToken);
        }

        /// <summary>
        /// Filter messages based on the <see cref="MailboxAddress"/> located in
        /// <see cref="MimeKit.MimeMessage.To">"TO" addresses</see>.
        /// </summary>
        /// <param name="messages">       The messages. </param>
        /// <param name="emailToAddress"> The email to address. </param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process filter messages in this collection.
        /// </returns>
        private IEnumerable<IndexedMimeMessage> FilterMessages(IEnumerable<IndexedMimeMessage> messages, string emailToAddress)
        {
            logger.Debug("Filtering messages for {0}.", emailToAddress);

            var filteredMessages = messages.Select(message => (Message: message, Recipients: message.Message.GetRecipients(true)))
            .Where(anon => anon.Recipients.Any(rec => rec.Address.Equals(emailToAddress, StringComparison.OrdinalIgnoreCase)))
            .Select(anon => anon.Message);

            return filteredMessages;
        }

        /// <summary> Filters messages based on their delivery status. </summary>
        /// <param name="messages"> The messages. </param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process filter bounced messages in this
        /// collection.
        /// </returns>
        private IEnumerable<IndexedMimeMessage> FilterBouncedMessages(IEnumerable<IndexedMimeMessage> messages)
        {
            logger.Debug("Filtering bounced messages.");

            return FilterMessages(messages, message => EmailHelper.IsBouncedMessage(message));
        }

        /// <summary>
        /// Filter messages based on the a user provided
        /// <see cref="Func{IndexedMimeMessage, Bool}">function</see>.
        /// </summary>
        /// <param name="messages"> The messages. </param>
        /// <param name="filter">   Specifies the filtering function. </param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process filter messages in this collection.
        /// </returns>
        private IEnumerable<IndexedMimeMessage> FilterMessages(IEnumerable<IndexedMimeMessage> messages, Func<IndexedMimeMessage, bool> filter)
        {
            logger.Trace("Filtering {0} messages.", messages.Count());

            var filteredMessages = new List<IndexedMimeMessage>();
            foreach (var message in messages)
            {
                logger.Trace("Filtering message {0}.", message.Index);
                if (filter(message))
                {
                    logger.Trace("Message {0} matches the filter criteria.", message.Index);
                    filteredMessages.Add(message);
                }
            }

            return filteredMessages;
        }

        #endregion
    }
}
