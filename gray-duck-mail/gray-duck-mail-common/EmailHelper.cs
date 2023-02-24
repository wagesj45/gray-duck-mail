using GrayDuckMail.Common.Database;
using GrayDuckMail.Common.Localization;
using HtmlAgilityPack;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        private static string defaultEmailTemplate = string.Empty;

        /// <summary> Describes if the email helper is using a URL for unsubscribing. </summary>
        private static bool usingUnsubscribeUri = false;

        /// <summary> The base URL to use when constructing externally accessable unsubscribe links. </summary>
        private static Uri unsubscribeUri;

        /// <summary> The secret token used for creating a secure unsubscribe link. </summary>
        private static string hashSecret = string.Empty;

        #endregion

        #region Properties

        /// <summary> Gets a value indicating whether the using unsubscribe URI. </summary>
        /// <value> True if using unsubscribe uri, false if not. </value>
        public static bool UsingUnsubscribeUri
        {
            get => usingUnsubscribeUri;
        }

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
                    logger.Info(LanguageHelper.GetValue(ResourceName.Logger_LoadingHTMLTemplate));

                    var assembly = Assembly.GetAssembly(typeof(EmailHelper));
                    logger.Debug(LanguageHelper.FormatValue(ResourceName.Logger_Format_LoadingAssembly, assembly.FullName));

                    logger.Debug(LanguageHelper.GetValue(ResourceName.Logger_FoundResources));
                    foreach (var name in assembly.GetManifestResourceNames())
                    {
                        logger.Debug(LanguageHelper.FormatValue(ResourceName.Logger_FoundResourcesLine, name));
                    }

                    var stream = assembly.GetManifestResourceStream("GrayDuckMail.Common.EmailTemplates.Main.html");

                    using (var reader = new StreamReader(stream))
                    {
                        defaultEmailTemplate = reader.ReadToEnd();

                        logger.Debug(LanguageHelper.GetValue(ResourceName.Logger_TemplateInMemory));
                        logger.Trace(defaultEmailTemplate);
                    }
                }

                return defaultEmailTemplate;
            }
        }

        #endregion

        #region Methods

        /// <summary> Configures an externally accessible unsubscribe link. </summary>
        /// <param name="baseUrl">    The base URL. </param>
        /// <param name="secure">     True if using HTTPS, false if not. </param>
        /// <param name="hashSecret">
        ///     The secret token used for creating a secure unsubscribe link.
        /// </param>
        public static void ConfigureUnsubscribeLink(string baseUrl, bool secure, string hashSecret)
        {
            var builder = new UriBuilder();
            builder.Scheme = secure ? "https" : "http";
            builder.Host = baseUrl;
           
            unsubscribeUri = builder.Uri;
            usingUnsubscribeUri = true;
            EmailHelper.hashSecret = hashSecret;
        }

        /// <summary> Fill the default HTML email template with values. </summary>
        /// <param name="heading">        The heading. </param>
        /// <param name="subheading">     The subheading. </param>
        /// <param name="body">           The body. </param>
        /// <param name="footer">         The footer. </param>
        /// <param name="discussionList"> The discussion list. </param>
        /// <returns> A string with a processed main email template. </returns>
        public static string FillDefaultTemplate(string heading, string subheading, string body, string footer, DiscussionList discussionList, Contact contact)
        {
            var unsubscribe = string.Empty;

            if (UsingUnsubscribeUri)
            {
                var unsubscriptionLink = GetUnsubscribeLink(discussionList, contact);

                unsubscribe = unsubscriptionLink;
            }
            else
            {
                //Create a fallback link to the unsubscribe email alias.
                unsubscribe = string.Format("mailto:{0}?subject=Unsubscribing", EmailAliasHelper.GetUnsubscribeAlias(discussionList));
            }

            var result = DefaultEmailTemplate
                .Replace("{heading}", heading)
                .Replace("{subheading}", subheading)
                .Replace("{body}", body)
                .Replace("{footer}", footer)
                .Replace("{unsubscribe}", unsubscribe);

            logger.Debug(LanguageHelper.GetValue(ResourceName.Logger_Format_TemplateProcessed));
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
                logger.Error(LanguageHelper.GetValue(ResourceName.Logger_EmptyDiscussionList));
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
                logger.Error(LanguageHelper.GetValue(ResourceName.Logger_EmptyDiscussionList));
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
            logger.Debug(LanguageHelper.FormatValue(ResourceName.Logger_RelayingMessage, recipient.Name, recipient.Email));

            var relay = SendEmail(discussionList,
                recipient,
                LanguageHelper.FormatValue(ResourceName.Mail_Format_Subject, message.Subject.Replace(LanguageHelper.FormatValue(ResourceName.Mail_Format_SubjectReplace, discussionList.Name), ""), discussionList.Name),
                discussionList.BaseEmailAddress,
                () =>
                {
                    if (!string.IsNullOrWhiteSpace(message.BodyHTML))
                    {
                        logger.Debug(LanguageHelper.GetValue(ResourceName.Logger_MessageContainsHTML));

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
                        if (UsingUnsubscribeUri)
                        {
                            var unsubscriptionLink = GetUnsubscribeLink(discussionList, recipient);

                            techHeader.InnerHtml = LanguageHelper.FormatValue(ResourceName.Mail_Format_HTMLUnsubscribeLinkMessage, discussionList.Name, unsubscriptionLink);
                        }
                        else
                        {
                            //Create a fallback link to the unsubscribe email alias.
                            techHeader.InnerHtml = LanguageHelper.FormatValue(ResourceName.Mail_Format_HTMLUnsubscribeEmailMessage, discussionList.Name, EmailAliasHelper.GetUnsubscribeAlias(discussionList));
                        }
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
                        logger.Debug(LanguageHelper.GetValue(ResourceName.Logger_MessageContainsPlainText));

                        var techHeader = string.Empty;
                        if(UsingUnsubscribeUri)
                        {
                            var unsubscriptionLink = GetUnsubscribeLink(discussionList, recipient);

                            techHeader = LanguageHelper.FormatValue(ResourceName.Mail_Format_TextUnsubscribeLinkMessage, discussionList.Name, unsubscriptionLink);
                        }
                        else
                        {
                            //Create a fallback link to the unsubscribe email alias.
                            techHeader = LanguageHelper.FormatValue(ResourceName.Mail_Format_TextUnsubscribeEmailMessage, discussionList.Name, EmailAliasHelper.GetUnsubscribeAlias(discussionList));
                        }
                        var cleanedText = message.BodyText.Replace(techHeader, "");
                        var modifiedText = string.Format("{0}{1}{2}", cleanedText, Environment.NewLine, techHeader);

                        return new TextPart(TextFormat.Text)
                        {
                            Text = modifiedText
                        };
                    }

                    var formatException = new FormatException(LanguageHelper.GetValue(ResourceName.Exception_FormatNotDetermined));

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
            logger.Info(LanguageHelper.FormatValue(ResourceName.Logger_Format_SendingOnboardingEmail, recipient.Name, recipient.Email));

            SendEmail(discussionList,
                recipient,
                LanguageHelper.FormatValue(ResourceName.Mail_Format_OnboardingSubject, discussionList.Name),
                EmailAliasHelper.GetSubscribeAlias(discussionList),
                () =>
                {
                    return new TextPart(TextFormat.Html)
                    {
                        Text = EmailHelper.FillDefaultTemplate(
                            LanguageHelper.GetValue(ResourceName.Mail_OnboardingHeading),
                            LanguageHelper.FormatValue(ResourceName.Mail_Format_OnboardingSubheading, discussionList.Name),
                            LanguageHelper.FormatValue(ResourceName.Mail_Format_OnboardingBody, discussionList.Name),
                            discussionList.Name,
                            discussionList,
                            recipient
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
            logger.Info(LanguageHelper.FormatValue(ResourceName.Logger_Format_SendingOwnerNotification, requester.Name, requester.Email, discussionList.Name));
            var ownerContact = new Contact() { Name = LanguageHelper.GetValue(ResourceName.Mail_Owner), Email = EmailAliasHelper.GetOwnerAlias(discussionList), Activated = true };

            SendEmail(discussionList,
                ownerContact,
                LanguageHelper.FormatValue(ResourceName.Mail_Format_OwnerNotificationSubject, discussionList.Name),
                EmailAliasHelper.GetSubscribeAlias(discussionList),
                () =>
                {
                    return new TextPart(TextFormat.Html)
                    {
                        Text = EmailHelper.FillDefaultTemplate(
                            LanguageHelper.GetValue(ResourceName.Mail_OwnerNotificationHeading),
                            LanguageHelper.FormatValue(ResourceName.Mail_Format_OwnerNotificationSubheading, requester.Name, discussionList.Name),
                            LanguageHelper.GetValue(ResourceName.Mail_OwnerNotificationBody),
                            discussionList.Name,
                            discussionList,
                            ownerContact
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
            logger.Info(LanguageHelper.FormatValue(ResourceName.Logger_Format_SendingSubscriptionConfirmation, recipient.Name, recipient.Email));

            SendEmail(discussionList,
                recipient,
                LanguageHelper.FormatValue(ResourceName.Mail_Format_SubscriptionConfirmationSubject, discussionList.Name),
                discussionList.BaseEmailAddress,
                () =>
                {
                    return new TextPart(TextFormat.Html)
                    {
                        Text = EmailHelper.FillDefaultTemplate(
                            LanguageHelper.GetValue(ResourceName.Mail_SubscriptionConfirmationHeading),
                            LanguageHelper.FormatValue(ResourceName.Mail_Format_SubscriptionConfirmationSubheading, discussionList.Name),
                            LanguageHelper.FormatValue(ResourceName.Mail_Format_SubscriptionConfirmationBody, discussionList.BaseEmailAddress),
                            discussionList.Name,
                            discussionList,
                            recipient
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
            logger.Info(LanguageHelper.FormatValue(ResourceName.Logger_Format_SendingUnsubscriptionConfirmation), recipient.Name, recipient.Email);

            SendEmail(discussionList,
                recipient,
                LanguageHelper.FormatValue(ResourceName.Mail_Format_UnsubscriptionConfirmationSubject, discussionList.Name),
                discussionList.BaseEmailAddress,
                () =>
                {
                    return new TextPart(TextFormat.Html)
                    {
                        Text = EmailHelper.FillDefaultTemplate(
                            LanguageHelper.GetValue(ResourceName.Mail_UnsubscriptionConfirmationHeading),
                            LanguageHelper.FormatValue(ResourceName.Mail_Format_UnsubscriptionConfirmationSubheading, discussionList.Name),
                            LanguageHelper.FormatValue(ResourceName.Mail_Format_UnsubscriptionConfirmationBody, EmailAliasHelper.GetRequestAlias(discussionList)),
                            discussionList.Name,
                            discussionList,
                            recipient
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
            logger.Debug(LanguageHelper.GetValue(ResourceName.Logger_GeneratingEmail));

            var unsubscribeHeader = new StringBuilder();
            unsubscribeHeader.AppendFormat("<mailto:{0}>", EmailAliasHelper.GetUnsubscribeAlias(discussionList));

            if(UsingUnsubscribeUri)
            {
                var unsubscriptionLink = GetUnsubscribeLink(discussionList, recipient);

                unsubscribeHeader.AppendFormat(",{0}<{1}>", Environment.NewLine, unsubscriptionLink);
            }

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(discussionList.Name, discussionList.BaseEmailAddress));
            message.ReplyTo.Add(new MailboxAddress(discussionList.Name, replyTo));
            message.To.Add(new MailboxAddress(recipient.Name, recipient.Email));
            message.Subject = subject;
            message.Headers.Insert(0, HeaderId.ReturnPath, string.Format("Bounces <{0}>", EmailAliasHelper.GetBounceAlias(discussionList)));
            message.Headers.Insert(1, HeaderId.ListUnsubscribe, unsubscribeHeader.ToString());
            message.Headers.Insert(2, HeaderId.ListUnsubscribePost, "List-Unsubscribe=One-Click");

            message.Body = bodyGenerator();

            if (!client.IsConnected)
            {
                logger.Info(LanguageHelper.GetValue(ResourceName.Logger_SMTPNotConnected));
                client.Connect(discussionList.OutgoingMailServer, discussionList.OutgoingMailPort, discussionList.UseSSL, cancellationToken: cancellationToken);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(discussionList.UserName, discussionList.Password, cancellationToken: cancellationToken);
            }

            client.Send(message, cancellationToken: cancellationToken);

            return message;
        }

        /// <summary> Gets the fully formed unsubscribe link. </summary>
        /// <param name="discussionList"> The discussion list. </param>
        /// <param name="recipient">      The recipient. </param>
        /// <returns> The unsubscribe link. </returns>
        private static string GetUnsubscribeLink(DiscussionList discussionList, Contact recipient)
        {
            var customized = new UriBuilder(unsubscribeUri);
            customized.Path = string.Format("Unsubscribe/{0}/{1}/{2}", recipient.ID, discussionList.ID, HashHelper.Hash(recipient.ID, discussionList.ID, hashSecret));
            return customized.Uri.AbsoluteUri;
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
                logger.Debug(LanguageHelper.GetValue(ResourceName.Logger_DeliveryStatusDetected));
                foreach (var deliveryStatus in multipartMessage.OfType<MessageDeliveryStatus>())
                {
                    foreach (var statusGroup in deliveryStatus.StatusGroups)
                    {
                        var action = statusGroup["Action"];

                        if (action != null)
                        {
                            if (BouncedEmailStatusGroupActions.Contains(action.ToLowerInvariant()))
                            {
                                logger.Debug(LanguageHelper.GetValue(ResourceName.Logger_FailedDeliveryDetected));

                                var recipient = statusGroup["Original-Recipient"]
                                    ?? statusGroup["Failed-Recipient"]
                                    ?? statusGroup["Final-Recipient"];

                                var address = recipient != null ? recipient.Split(';')[1] : string.Empty;

                                if (string.IsNullOrWhiteSpace(address))
                                {
                                    logger.Error(LanguageHelper.GetValue(ResourceName.Logger_FailureDetectedUnknownRecipient));

                                    foreach (var group in statusGroup)
                                    {
                                        logger.Debug(LanguageHelper.FormatValue(ResourceName.Logger_Format_FailureStatusGroupsLine, group.Field, group.Value));
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
