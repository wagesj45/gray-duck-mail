using EasyMailDiscussion.Common.Database;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace EasyMailDiscussion.Common
{
    public static class EmailHelper
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public const string STATUS_GROUP_ACTION_FAILED = "failed";

        /// <summary> (Immutable) The string denoting the status group action delayed. </summary>
        public const string STATUS_GROUP_ACTION_DELAYED = "delayed";

        /// <summary> The main HTML email template. </summary>
        private static string mailEmailTemplate;

        #endregion

        #region Properties

        /// <summary> Gets the authorized subscription statuses. </summary>
        /// <value> The authorized statuses. </value>
        public static IEnumerable<SubscriptionStatus> ContactAuthorizedStatuses
        {
            get
            {
                yield return SubscriptionStatus.Subscribed;
                yield return SubscriptionStatus.Inactive;
            }
        }

        /// <summary> Gets the associated subscription statuses. </summary>
        /// <value> The associated statuses. </value>
        public static IEnumerable<SubscriptionStatus> ContactAssociatedStatuses
        {
            get
            {
                yield return SubscriptionStatus.Created;
                yield return SubscriptionStatus.Inactive;
                yield return SubscriptionStatus.Subscribed;
            }
        }

        /// <summary> Gets the contact unassignable statuses. </summary>
        /// <value> The contact unassignable statuses. </value>
        public static IEnumerable<SubscriptionStatus> ContactUnassignableStatuses
        {
            get
            {
                yield return SubscriptionStatus.Unsubscribed;
                yield return SubscriptionStatus.Bounced;
            }
        }

        /// <summary> Gets the bounced email status group action values. </summary>
        /// <value> The bounced email status group action values. </value>
        public static IEnumerable<string> BouncedEmailStatusGroupActions
        {
            get
            {
                yield return STATUS_GROUP_ACTION_FAILED;
                yield return STATUS_GROUP_ACTION_DELAYED;
            }
        }

        /// <summary> Gets the HTML email template. </summary>
        /// <value> The mail email template. </value>
        public static string MailEmailTemplate
        {
            get
            {
                if (string.IsNullOrEmpty(mailEmailTemplate))
                {
                    logger.Info("Loading main HTML email template.");

                    var assembly = Assembly.GetAssembly(typeof(EmailHelper));
                    logger.Debug("Loading assembly {0}", assembly.FullName);

                    logger.Debug("Found the following resource names in the assembly manifest:");
                    foreach (var name in assembly.GetManifestResourceNames())
                    {
                        logger.Debug("-- {0}", name);
                    }

                    var stream = assembly.GetManifestResourceStream("EasyMailDiscussion.Common.EmailTemplates.Main.html");

                    using (var reader = new StreamReader(stream))
                    {
                        mailEmailTemplate = reader.ReadToEnd();

                        logger.Debug("Email template read into memory.");
                        logger.Trace(mailEmailTemplate);
                    }
                }

                return mailEmailTemplate;
            }
        }

        #endregion

        #region Methods

        /// <summary> Fill main HTML email template. </summary>
        /// <param name="heading">        The heading. </param>
        /// <param name="subheading">     The subheading. </param>
        /// <param name="body">           The body. </param>
        /// <param name="footer">         The footer. </param>
        /// <param name="discussionList"> the Discussion List database object. </param>
        /// <returns> A string with a processed main email template. </returns>
        public static string FillMainTemplate(string heading, string subheading, string body, string footer, DiscussionList discussionList)
        {
            var result = MailEmailTemplate
                .Replace("{heading}", heading)
                .Replace("{subheading}", subheading)
                .Replace("{body}", body)
                .Replace("{footer}", footer)
                .Replace("{unsubscribe}", string.Format("mailto:{0}?subject=Unsubscribing", EmailAliasHelper.GetUnsubscribeAlias(discussionList)));

            logger.Debug("Email template processed: {0}");
            logger.Trace(result);

            return result;
        }

        /// <summary> Query if a given user is authorized for mail distribution on a given discussion list. </summary>
        /// <param name="discussionList"> the Discussion List database object. </param>
        /// <param name="contact">        The contact. </param>
        /// <returns> True if authorized for mail distribution, false if not. </returns>
        public static bool IsAuthorizedForMailDistribution(DiscussionList discussionList, Contact contact)
        {
            if (discussionList.Contacts == null || !discussionList.Contacts.Any())
            {
                logger.Error("The discussion list is empty.");
                return false;
            }
            return contact.Activated && discussionList.Contacts.Where(subscription => subscription.Contact.ID == contact.ID && ContactAuthorizedStatuses.Contains(subscription.Status)).Any();
        }

        /// <summary> Query if a given user can be assigned to a discussion list. </summary>
        /// <param name="discussionList"> the Discussion List database object. </param>
        /// <param name="contact">        The contact. </param>
        /// <returns> True if assignable, false if not. </returns>
        public static bool IsAssignable(DiscussionList discussionList, Contact contact)
        {
            if (discussionList.Contacts == null || !discussionList.Contacts.Any())
            {
                logger.Error("The discussion list is empty.");
                return false;
            }
            return discussionList.Contacts.Where(subscription => subscription.Contact.ID == contact.ID && !ContactUnassignableStatuses.Contains(subscription.Status)).Any();
        }

        public static void RelayEmail(DiscussionList discussionList, Contact recipient, Message message, SqliteDatabase database, SmtpClient client, CancellationToken stoppingToken = default)
        {
            logger.Debug("Relaying message to {0} ({1})", recipient.Name, recipient.Email);

            var relay = SendEmail(discussionList,
                recipient,
                string.Format("{0} - Message from {1}", message.Subject.Replace(String.Format(" - Message from {0}", discussionList.Name), ""), discussionList.Name),
                discussionList.BaseEmailAddress,
                () =>
                {
                    if (!string.IsNullOrWhiteSpace(message.BodyHTML))
                    {
                        logger.Debug("Mesasge body determined to contain HTML.");
                        return new TextPart(TextFormat.Html)
                        {
                            Text = message.BodyHTML
                        };
                    }

                    if (!string.IsNullOrWhiteSpace(message.BodyText))
                    {
                        logger.Debug("Message body determined to contain plain text.");
                        return new TextPart(TextFormat.Text)
                        {
                            Text = message.BodyText
                        };
                    }

                    var formatException = new FormatException("Could not determine the formatting of the message.");

                    throw formatException;
                },
                client,
                stoppingToken
                );

            var relayIdentifier = new RelayIdentifier()
            {
                Message = message,
                RelayEmailID = relay.MessageId
            };
            database.RelayIdentifiers.Add(relayIdentifier);
        }

        public static void SendOnboardingEmail(DiscussionList discussionList, Contact recipient, SmtpClient client, CancellationToken cancellationToken = default)
        {
            SendEmail(discussionList,
                recipient,
                string.Format("Subscribe to {0}", discussionList.Name),
                EmailAliasHelper.GetSubscribeAlias(discussionList),
                () =>
                {
                    return new TextPart(TextFormat.Html)
                    {
                        Text = EmailHelper.FillMainTemplate(
                            "Welcome!",
                            String.Format("You've been invited to the '{0}' Email Discussion List", discussionList.Name),
                            String.Format("The '{0}' email list administator has invited you to participate. To confirm your subscription, simply reply to this e-mail. If you do not wish to participate, you can ignore this email.", discussionList.Name),
                            discussionList.Name,
                            discussionList
                            )
                    };
                },
                client,
                cancellationToken);
        }

        /// <summary> Sends an email. </summary>
        /// <remarks>
        /// The <paramref name="client"/> will connect to the SMTP server defined in
        /// <paramref name="discussionList"/> if the client is disconnected. The client will not
        /// disconnect at the end of this method.
        /// </remarks>
        /// <param name="discussionList">    The Discussion List database object. </param>
        /// <param name="recipient">         The recipient. </param>
        /// <param name="subject">           The subject. </param>
        /// <param name="bodyGenerator">     The body generator function. </param>
        /// <param name="client">            The SMTP client. </param>
        /// <param name="cancellationToken">
        ///     (Optional) A token that allows processing to be cancelled.
        /// </param>
        public static MimeMessage SendEmail(DiscussionList discussionList, Contact recipient, string subject, string replyTo, Func<MimeEntity> bodyGenerator, SmtpClient client, CancellationToken cancellationToken = default)
        {
            logger.Debug("Generating an email.");

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(discussionList.Name, discussionList.BaseEmailAddress));
            message.ReplyTo.Add(new MailboxAddress(discussionList.Name, replyTo));
            message.To.Add(new MailboxAddress(recipient.Name, recipient.Email));
            message.Subject = subject;
            message.Headers.Insert(0, HeaderId.ReturnPath, string.Format("Bounces <{0}>","jordan@jordanwages.com"));

            message.Body = bodyGenerator();

            if (!client.IsConnected)
            {
                logger.Info("The SMTP client is not connected. Connecting now.");
                client.Connect(discussionList.OutgoingMailServer, discussionList.OutgoingMailPort, discussionList.UseSSL, cancellationToken: cancellationToken);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(discussionList.UserName, discussionList.Password, cancellationToken: cancellationToken);
            }

            client.Send(message, cancellationToken: cancellationToken);

            return message;
        }

        /// <summary> Query if a messaged is a bounced message by determining if there is an error action code per <see cref="GetBouncedMessageRecipient(IndexedMimeMessage)"/>. </summary>
        /// <param name="message"> The message. </param>
        /// <returns> True if the message is bounced, false if not. </returns>
        public static bool IsBouncedMessage(IndexedMimeMessage message)
        {
            var bounced = !string.IsNullOrWhiteSpace(GetBouncedMessageRecipient(message));

            return bounced;
        }

        /// <summary> Gets bounced message recipient from the message, if it exists. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are null.
        /// </exception>
        /// <param name="message"> The message. </param>
        /// <returns> The bounced message recipient. </returns>
        public static string GetBouncedMessageRecipient(IndexedMimeMessage message)
        {
            if(message == null)
            {
                var argumentException = new ArgumentNullException(nameof(message));
                logger.Error(argumentException);

                throw argumentException;
            }

            var multipartMessage = message.Message.Body as Multipart;

            if(multipartMessage != null && multipartMessage.OfType<MessageDeliveryStatus>().Any())
            {
                logger.Debug("Message is a multipart message with at least one 'delivery-status' section.");
                foreach(var deliveryStatus in multipartMessage.OfType<MessageDeliveryStatus>())
                {
                    foreach(var statusGroup in deliveryStatus.StatusGroups)
                    {
                        var action = statusGroup["Action"].ToLowerInvariant();

                        if (BouncedEmailStatusGroupActions.Contains(action))
                        {
                            logger.Debug("A failed delivery was detected.");

                            var recipient = statusGroup["Original-Recipient"];
                            var address = recipient != null ? recipient.Split(';')[1] : string.Empty;

                            return address.Trim().ToLowerInvariant();
                        }
                    }
                }
            }

            return string.Empty;
        }

        #endregion
    }
}
