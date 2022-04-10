using GrayDuckMail.Common.Database;
using HtmlAgilityPack;
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

namespace GrayDuckMail.Common
{
    /// <summary>
    /// A helper class that contains data and methods for manipulating and processing email data.
    /// </summary>
    public static class EmailHelper
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary> (Immutable) The string denoting the MIME status for a failed email message. </summary>
        public const string STATUS_GROUP_ACTION_FAILED = "failed";

        /// <summary> (Immutable) The string denoting the MIME status for a delayed email message. </summary>
        public const string STATUS_GROUP_ACTION_DELAYED = "delayed";

        /// <summary> The main HTML email template. </summary>
        private static string defaultEmailTemplate;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the <see cref="SubscriptionStatus"/> values that indicate a <see cref="Contact"/> is
        /// authorized to send <see cref="Message">messages</see> through the
        /// <see cref="DiscussionList">discussion list</see>.
        /// </summary>
        /// <value> The authorized statuses. </value>
        public static IEnumerable<SubscriptionStatus> ContactAuthorizedStatuses
        {
            get
            {
                yield return SubscriptionStatus.Subscribed;
                yield return SubscriptionStatus.AwaitingConfirmation;
            }
        }

        /// <summary>
        /// Gets the <see cref="SubscriptionStatus"/> values that indicate that a <see cref="Contact"/>
        /// is <see cref="ContactSubscription">assigned</see> to a <see cref="DiscussionList">discussion
        /// list</see>.
        /// </summary>
        /// <value> The associated statuses. </value>
        public static IEnumerable<SubscriptionStatus> ContactAssociatedStatuses
        {
            get
            {
                yield return SubscriptionStatus.Created;
                yield return SubscriptionStatus.AwaitingConfirmation;
                yield return SubscriptionStatus.Subscribed;
            }
        }

        /// <summary>
        /// Gets the <see cref="SubscriptionStatus"/> values that indicate that a <see cref="Contact"/>
        /// cannot be <see cref="ContactSubscription">assigned</see> to a
        /// <see cref="DiscussionList">discussion list</see>.
        /// </summary>
        /// <value> The contact unassignable statuses. </value>
        public static IEnumerable<SubscriptionStatus> ContactUnassignableStatuses
        {
            get
            {
                yield return SubscriptionStatus.Unsubscribed;
                yield return SubscriptionStatus.Bounced;
                yield return SubscriptionStatus.Created;
                yield return SubscriptionStatus.AwaitingConfirmation;
            }
        }

        /// <summary> Gets the MIME values indicating a bounced email. </summary>
        /// <value> The bounced email status group action values. </value>
        /// <seealso cref="STATUS_GROUP_ACTION_FAILED"/>
        /// <seealso cref="STATUS_GROUP_ACTION_DELAYED"/>
        public static IEnumerable<string> BouncedEmailStatusGroupActions
        {
            get
            {
                yield return STATUS_GROUP_ACTION_FAILED;
                yield return STATUS_GROUP_ACTION_DELAYED;
            }
        }

        /// <summary> Gets the default HTML email template. </summary>
        /// <remarks>
        /// <para>
        /// This email template contains several replaceable notaions: <c>{header}</c>,
        /// <c>{subheader}</c>, <c>{body}</c>, and <c>{footer}</c>. The <c>{unsubscribe}</c> notation
        /// should always be a link to the
        /// <see cref="EmailAliasHelper.GetUnsubscribeAlias(DiscussionList)">unsubscribe email
        /// alias</see>.
        /// </para>
        /// <para>
        /// This file is read into memory upon its first access.
        /// </para>
        /// </remarks>
        /// <value> The mail email template. </value>
        public static string DefaultEmailTemplate
        {
            get
            {
                if (string.IsNullOrEmpty(defaultEmailTemplate))
                {
                    logger.Info("Loading main HTML email template.");

                    var assembly = Assembly.GetAssembly(typeof(EmailHelper));
                    logger.Debug("Loading assembly {0}", assembly.FullName);

                    logger.Debug("Found the following resource names in the assembly manifest:");
                    foreach (var name in assembly.GetManifestResourceNames())
                    {
                        logger.Debug("-- {0}", name);
                    }

                    var stream = assembly.GetManifestResourceStream("GrayDuckMail.Common.EmailTemplates.Main.html");

                    using (var reader = new StreamReader(stream))
                    {
                        defaultEmailTemplate = reader.ReadToEnd();

                        logger.Debug("Email template read into memory.");
                        logger.Trace(defaultEmailTemplate);
                    }
                }

                return defaultEmailTemplate;
            }
        }

        #endregion

        #region Methods

        /// <summary> Fill the default HTML email template with values. </summary>
        /// <param name="heading">        The heading. </param>
        /// <param name="subheading">     The subheading. </param>
        /// <param name="body">           The body. </param>
        /// <param name="footer">         The footer. </param>
        /// <param name="discussionList"> The discussion list. </param>
        /// <returns> A string with a processed main email template. </returns>
        public static string FillDefaultTemplate(string heading, string subheading, string body, string footer, DiscussionList discussionList)
        {
            var result = DefaultEmailTemplate
                .Replace("{heading}", heading)
                .Replace("{subheading}", subheading)
                .Replace("{body}", body)
                .Replace("{footer}", footer)
                .Replace("{unsubscribe}", string.Format("mailto:{0}?subject=Unsubscribing", EmailAliasHelper.GetUnsubscribeAlias(discussionList)));

            logger.Debug("Email template processed: {0}");
            logger.Trace(result);

            return result;
        }

        /// <summary>
        /// Query if a given user is authorized for mail distribution on a given discussion list.
        /// </summary>
        /// <param name="discussionList"> The discussion list. </param>
        /// <param name="contact">        The contact. </param>
        /// <returns> True if authorized for mail distribution, false if not. </returns>
        public static bool IsAuthorizedForMailDistribution(DiscussionList discussionList, Contact contact)
        {
            if (discussionList.Subscriptions == null || !discussionList.Subscriptions.Any())
            {
                logger.Error("The discussion list is empty.");
                return false;
            }
            var authorized = discussionList.Subscriptions.Where(subscription => subscription.Contact.ID == contact.ID && ContactAssociatedStatuses.Contains(subscription.Status)).Any();

            return authorized;
        }

        /// <summary> Query if a given user can be assigned to a discussion list. </summary>
        /// <param name="discussionList"> The discussion list. </param>
        /// <param name="contact">        The contact. </param>
        /// <returns> True if assignable, false if not. </returns>
        public static bool IsAssignable(DiscussionList discussionList, Contact contact)
        {
            if (discussionList.Subscriptions == null || !discussionList.Subscriptions.Any())
            {
                logger.Error("The discussion list is empty.");
                return false;
            }
            var assignable = discussionList.Subscriptions.Where(subscription => subscription.Contact.ID == contact.ID && !ContactUnassignableStatuses.Contains(subscription.Status)).Any();

            return assignable;
        }

        /// <summary>
        /// Relay an email to the <see cref="Contact">contacts</see>
        /// <see cref="ContactSubscription">assigned</see> to a <see cref="DiscussionList">discussion
        /// list</see>.
        /// </summary>
        /// <exception cref="FormatException">
        ///     Thrown when the format of an input is incorrect.
        /// </exception>
        /// <param name="discussionList"> The discussion list. </param>
        /// <param name="recipient">      The recipient. </param>
        /// <param name="message">        The message. </param>
        /// <param name="database">       The database. </param>
        /// <param name="client">         The SMTP client. </param>
        /// <param name="stoppingToken">
        ///     (Optional) A token that allows processing to be cancelled.
        /// </param>
        /// <seealso cref="SendEmail(DiscussionList, Contact, string, string, Func{MimeEntity}, SmtpClient, CancellationToken)"/>
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

                        var html = new HtmlDocument();
                        html.LoadHtml(message.BodyHTML);

                        HtmlNode bodyNode = null;
                        if (html.DocumentNode.SelectNodes("//body")?.Any() ?? false)
                        {
                            bodyNode = html.DocumentNode.SelectNodes("//body").FirstOrDefault();
                        }

                        if (bodyNode == null)
                        {
                            //If we couldn't find a <body> tag, let's assume it not a full html 
                            // build and just attach to the document node directly.

                            bodyNode = html.DocumentNode;
                        }

                        var techHeader = html.CreateElement("mark");
                        techHeader.InnerHtml = String.Format("This message is part of the '{0}' discussion list. You can unsubscribe by sending any message to <a href='mailto:{1}'>{1}</a>", discussionList.Name, EmailAliasHelper.GetUnsubscribeAlias(discussionList));
                        bodyNode.AppendChild(techHeader);

                        var cleanedHtmlString = html.DocumentNode.InnerHtml.Replace(techHeader.InnerHtml, "");
                        var modifiedHtml = html.DocumentNode.InnerHtml;

                        return new TextPart(TextFormat.Html)
                        {
                            Text = modifiedHtml
                        };
                    }

                    if (!string.IsNullOrWhiteSpace(message.BodyText))
                    {
                        logger.Debug("Message body determined to contain plain text.");

                        var techHeader = string.Format("This message is part of the '{0}' discussion list. You can unsubscribe by sending any message to {1}.", discussionList.Name, EmailAliasHelper.GetUnsubscribeAlias(discussionList));
                        var cleanedText = message.BodyText.Replace(techHeader, "");
                        var modifiedText = string.Format("{0}{1}{2}", cleanedText, Environment.NewLine, techHeader);

                        return new TextPart(TextFormat.Text)
                        {
                            Text = modifiedText
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

        /// <summary>
        /// Sends an onboarding email asking a <see cref="Contact">contact</see> to subscribe to a
        /// <see cref="DiscussionList">discussion list</see>.
        /// </summary>
        /// <param name="discussionList">    The discussion list. </param>
        /// <param name="recipient">         The recipient. </param>
        /// <param name="client">            The SMTP client. </param>
        /// <param name="cancellationToken">
        ///     (Optional) A token that allows processing to be cancelled.
        /// </param>
        /// <seealso cref="SendEmail(DiscussionList, Contact, string, string, Func{MimeEntity}, SmtpClient, CancellationToken)"/>
        public static void SendOnboardingEmail(DiscussionList discussionList, Contact recipient, SmtpClient client, CancellationToken cancellationToken = default)
        {
            logger.Info("Sending onboarding email to {0} ({1}).", recipient.Name, recipient.Email);

            SendEmail(discussionList,
                recipient,
                string.Format("Subscribe to {0}", discussionList.Name),
                EmailAliasHelper.GetSubscribeAlias(discussionList),
                () =>
                {
                    return new TextPart(TextFormat.Html)
                    {
                        Text = EmailHelper.FillDefaultTemplate(
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

        /// <summary>
        /// Sends a notification to the
        /// <see cref="EmailAliasHelper.GetOwnerAlias(DiscussionList)">owner</see> that a request to join
        /// the mailing list has been issued.
        /// </summary>
        /// <param name="discussionList">    The discussion list. </param>
        /// <param name="requester">         The requester. </param>
        /// <param name="client">            The SMTP client. </param>
        /// <param name="cancellationToken">
        ///     (Optional) A token that allows processing to be cancelled.
        /// </param>
        public static void SendRequestOwnerNotificationEmail(DiscussionList discussionList, Contact requester, SmtpClient client, CancellationToken cancellationToken = default)
        {
            logger.Info("Sending a notication to the discussion list owner that {0} ({1}) has requested access to {2}.", requester.Name, requester.Email, discussionList.Name);

            SendEmail(discussionList,
                new Contact() { Name = "Owner", Email = EmailAliasHelper.GetOwnerAlias(discussionList), Activated = true },
                string.Format("Request to join {0}", discussionList.Name),
                EmailAliasHelper.GetSubscribeAlias(discussionList),
                () =>
                {
                    return new TextPart(TextFormat.Html)
                    {
                        Text = EmailHelper.FillDefaultTemplate(
                            "Discussion List Access Request",
                            String.Format("{0} has requested access to the '{0}' Email Discussion List", requester.Name, discussionList.Name),
                            "Please visit the the web administration interface to process this request.",
                            discussionList.Name,
                            discussionList
                            )
                    };
                },
                client,
                cancellationToken);
        }

        /// <summary>
        /// Sends a subscription confirmation email to a <see cref="Contact">contact</see> that has
        /// subscribed to a <see cref="DiscussionList">discussion list</see>.
        /// </summary>
        /// <param name="discussionList">    The discussion list. </param>
        /// <param name="recipient">         The recipient. </param>
        /// <param name="client">            The SMTP client. </param>
        /// <param name="cancellationToken">
        ///     (Optional) A token that allows processing to be cancelled.
        /// </param>
        /// <seealso cref="SendEmail(DiscussionList, Contact, string, string, Func{MimeEntity}, SmtpClient, CancellationToken)"/>
        public static void SendSubscriptionConfirmationEmail(DiscussionList discussionList, Contact recipient, SmtpClient client, CancellationToken cancellationToken = default)
        {
            logger.Info("Sending the subscription confirmation email to {0} ({1}).", recipient.Name, recipient.Email);

            SendEmail(discussionList,
                recipient,
                string.Format("Welcome to {0}", discussionList.Name),
                discussionList.BaseEmailAddress,
                () =>
                {
                    return new TextPart(TextFormat.Html)
                    {
                        Text = EmailHelper.FillDefaultTemplate(
                            "Thanks for subscribing!",
                            String.Format("You've been subscribed to the '{0}' Email Discussion List", discussionList.Name),
                            String.Format("Glad to have you. To send a message to everyone on the discussion list, just send an email to <a href='mailto:{0}'>{0}</a>. When you recieve a message from someone in the group, you can simply reply to that email and everyone on the discussion list will get a copy.", discussionList.BaseEmailAddress),
                            discussionList.Name,
                            discussionList
                            )
                    };
                },
                client,
                cancellationToken);
        }

        /// <summary> Sends a confirmation email to a <see cref="Contact">contact</see> that has unsubscribed from a <see cref="DiscussionList">discussion list</see>. </summary>
        /// <param name="discussionList">    The discussion list. </param>
        /// <param name="recipient">         The recipient. </param>
        /// <param name="client">            The SMTP client. </param>
        /// <param name="cancellationToken">
        ///     (Optional) A token that allows processing to be cancelled.
        /// </param>
        /// <seealso cref="SendEmail(DiscussionList, Contact, string, string, Func{MimeEntity}, SmtpClient, CancellationToken)"/>
        public static void SendUnsubscriptionConfirmationEmail(DiscussionList discussionList, Contact recipient, SmtpClient client, CancellationToken cancellationToken = default)
        {
            logger.Info("Sending the subscription confirmation email to {0} ({1}).", recipient.Name, recipient.Email);

            SendEmail(discussionList,
                recipient,
                string.Format("You have been unsubscribed from {0}.", discussionList.Name),
                discussionList.BaseEmailAddress,
                () =>
                {
                    return new TextPart(TextFormat.Html)
                    {
                        Text = EmailHelper.FillDefaultTemplate(
                            "Sorry to see you go.",
                            String.Format("You will no longer recieve messages from the '{0}' Email Discussion List", discussionList.Name),
                            String.Format("You have successfully unsubscribed from this discussion list. If you'd ever like to resubscribe, send a message to <a href='mailto:{0}'>{0}</a>.", EmailAliasHelper.GetRequestAlias(discussionList)),
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
        /// <param name="discussionList">    The discussion list. </param>
        /// <param name="recipient">         The recipient. </param>
        /// <param name="subject">           The subject. </param>
        /// <param name="replyTo">           The reply to. </param>
        /// <param name="bodyGenerator">     The <see cref="MimeEntity">body generator</see> function. </param>
        /// <param name="client">            The SMTP client. </param>
        /// <param name="cancellationToken"> (Optional) A token that allows processing to be cancelled. </param>
        /// <returns> A MimeMessage. </returns>
        public static MimeMessage SendEmail(DiscussionList discussionList, Contact recipient, string subject, string replyTo, Func<MimeEntity> bodyGenerator, SmtpClient client, CancellationToken cancellationToken = default)
        {
            logger.Debug("Generating an email.");

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(discussionList.Name, discussionList.BaseEmailAddress));
            message.ReplyTo.Add(new MailboxAddress(discussionList.Name, replyTo));
            message.To.Add(new MailboxAddress(recipient.Name, recipient.Email));
            message.Subject = subject;
            message.Headers.Insert(0, HeaderId.ReturnPath, string.Format("Bounces <{0}>", EmailAliasHelper.GetBounceAlias(discussionList)));

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

        /// <summary>
        /// Query if a messaged is a bounced message by determining if there is an error action code per
        /// <see cref="GetBouncedMessageRecipient(IndexedMimeMessage)"/>.
        /// </summary>
        /// <param name="message"> The message. </param>
        /// <returns> True if the message is bounced, false if not. </returns>
        /// <seealso cref="GetBouncedMessageRecipient(IndexedMimeMessage)"/>
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
            if (message == null)
            {
                var argumentException = new ArgumentNullException(nameof(message));
                logger.Error(argumentException);

                throw argumentException;
            }

            var multipartMessage = message.Message.Body as Multipart;

            if (multipartMessage != null && multipartMessage.OfType<MessageDeliveryStatus>().Any())
            {
                logger.Debug("Message is a multipart message with at least one 'delivery-status' section.");
                foreach (var deliveryStatus in multipartMessage.OfType<MessageDeliveryStatus>())
                {
                    foreach (var statusGroup in deliveryStatus.StatusGroups)
                    {
                        var action = statusGroup["Action"];

                        if(action != null)
                        {
                            if (BouncedEmailStatusGroupActions.Contains(action.ToLowerInvariant()))
                            {
                                logger.Debug("A failed delivery was detected.");

                                var recipient = statusGroup["Original-Recipient"] 
                                    ?? statusGroup["Failed-Recipient"]
                                    ?? statusGroup["Final-Recipient"];
                                
                                var address = recipient != null ? recipient.Split(';')[1] : string.Empty;

                                if(string.IsNullOrWhiteSpace(address))
                                {
                                    logger.Error("The bounced email contains a failure report, but an unknown recipient status group.");

                                    foreach(var group in statusGroup)
                                    {
                                        logger.Debug(string.Format("-- {0}: {1}", group.Field, group.Value));
                                    }

                                    return "UNKNOWN_ADDRESS";
                                }

                                return address.Trim().ToLowerInvariant();
                            }
                        }
                    }
                }
            }

            return string.Empty;
        }

        #endregion
    }
}
