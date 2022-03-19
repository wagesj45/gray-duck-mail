using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EasyMailDiscussion.Common
{
    public static class EmailHelper
    {
        private static string accessEmailTemplate;

        /// <summary> Gets the access email template. </summary>
        /// <remarks>
        /// Using the <see cref="Assembly"/> of the local <see cref="Resources.Language.Language"/>
        /// library, the embedded HTML template is extracted.
        /// </remarks>
        /// <value> The default email template. </value>
        private static string AccessEmailTemplate
        {
            get
            {
                if (string.IsNullOrEmpty(accessEmailTemplate))
                {
                    var assembly = Assembly.GetAssembly(typeof(ApplicationSetting));
                    var stream = assembly.GetManifestResourceStream("SurveyWebsite.General.EmailTemplates.access.html");
                    using (var reader = new StreamReader(stream))
                    {
                        accessEmailTemplate = reader.ReadToEnd();
                    }
                }
                return accessEmailTemplate;
            }
        }

        /// <summary> Fills the access email template with content. </summary>
        /// <param name="listURL">      URL of the survey list page. </param>
        /// <param name="viewStatsURL"> URL of the view statistics [age. </param>
        /// <returns> A string containing the raw HTML of of the template. </returns>
        private static string FillAccessEmailTemplate(string listURL, string viewStatsURL)
        {
            var result = AccessEmailTemplate
                .Replace("[date]", DateTime.Now.ToLongDateString())
                .Replace("[list_url]", listURL)
                .Replace("[view_stats_url]", viewStatsURL)
                .Replace("[unsubscribeLink]", string.Format("{0}/Account/Manage", ApplicationSettingsHelper.GetApplicationSetting<string>(ApplicationSetting.BaseURL)));
            return result;
        }
    }
}
