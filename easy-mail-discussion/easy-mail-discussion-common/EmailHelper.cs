using EasyMailDiscussion.Common.Database;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
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

        /// <summary> Gets the HTML email template. </summary>
        /// <value> The mail email template. </value>
        private static string MailEmailTemplate
        {
            get
            {
                if (string.IsNullOrEmpty(mailEmailTemplate))
                {
                    logger.Info("Loading main HTML email template.");
                    
                    var assembly = Assembly.GetAssembly(typeof(EmailHelper));
                    logger.Debug("Loading assembly {0}", assembly.FullName);
                    
                    foreach(var name in assembly.GetManifestResourceNames())
                    {
                        logger.Debug("-- {0}", name);
                    }
                    
                    var stream = assembly.GetManifestResourceStream("EasyMailDiscussion.EmailTemplates.Main.html");
                    
                    using (var reader = new StreamReader(stream))
                    {
                        mailEmailTemplate = reader.ReadToEnd();

                        logger.Debug("Email template read into memory: {0}", mailEmailTemplate);
                    }
                }

                return mailEmailTemplate;
            }
        }

        /// <summary> Fill main HTML email template. </summary>
        /// <param name="heading">        The heading. </param>
        /// <param name="subheading">     The subheading. </param>
        /// <param name="body">           The body. </param>
        /// <param name="footer">         The footer. </param>
        /// <param name="discussionList"> the Discussion List database object. </param>
        /// <returns> A string with a processed main email template. </returns>
        private static string FillMainTemplate(string heading, string subheading, string body, string footer, DiscussionList discussionList)
        {
            var result = MailEmailTemplate
                .Replace("{heading}", heading)
                .Replace("{subheading}", subheading)
                .Replace("{body}", body)
                .Replace("{footer}", footer)
                .Replace("{unsubscriibe}", string.Format("mailto:{0}?subject=Unsubscribing", EmailAliasHelper.GetUnsubscribeAlias(discussionList)));
            
            logger.Debug("Email template processed: {0}", result);

            return result;
        }
    }
}
