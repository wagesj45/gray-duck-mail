using EasyMailDiscussion.Common.Database;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EasyMailDiscussion.Common
{
    public static class EmailHelper
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary> The main HTML email template. </summary>
        private static string mailEmailTemplate;

        #endregion

        #region Properties

        /// <summary> Gets the authorized subscription statuses. </summary>
        /// <value> The authorized statuses. </value>
        public static IEnumerable<SubscriptionStatus> Authorized
        {
            get
            {
                yield return SubscriptionStatus.Subscribed;
                yield return SubscriptionStatus.Inactive;
            }
        }

        /// <summary> Gets the associated subscription statuses. </summary>
        /// <value> The associated statuses. </value>
        public static IEnumerable<SubscriptionStatus> Associated
        {
            get
            {
                yield return SubscriptionStatus.Created;
                yield return SubscriptionStatus.Inactive;
                yield return SubscriptionStatus.Subscribed;
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

        public static bool IsAuthorizedForMailDistribution(DiscussionList discussionList, Contact contact)
        {
            return discussionList.Contacts.Where(subscription => subscription.Contact.Email.Equals(contact.Email, StringComparison.OrdinalIgnoreCase) && Authorized.Contains(subscription.Status)).Any();
        }

        #endregion
    }
}
