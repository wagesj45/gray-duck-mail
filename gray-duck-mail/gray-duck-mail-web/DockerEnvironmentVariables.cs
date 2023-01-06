using GrayDuckMail.Common;
using GrayDuckMail.Common.Localization;
using System;

namespace GrayDuckMail.Web
{
    /// <summary>
    /// A class that defines default values for environment variables passed in from Docker, as well
    /// as accessors for those values.
    /// </summary>
    /// <seealso href="https://docs.docker.com/compose/environment-variables/"/>
    public static class DockerEnvironmentVariables
    {
        #region Members

        /// <summary> The docker environment varialbe for <see cref="FetchTime"/>. </summary>
        private static Lazy<TimeSpan> envFetchTime = new Lazy<TimeSpan>(() =>
        {

            var fetchTime = Environment.GetEnvironmentVariable("FETCH_TIME");
            if (TimeSpan.TryParse(fetchTime, out var time))
            {
                return time;
            }

            return TimeSpan.FromMinutes(5);
        });

        /// <summary> The docker environment variable for <see cref="RateLimitRoundWaitTime"/>. </summary>
        private static Lazy<TimeSpan> envRateLimitRoundWait = new Lazy<TimeSpan>(() =>
        {
            var waitTime = Environment.GetEnvironmentVariable("RATE_LIMIT_ROUND_WAIT_TIME");
            if (TimeSpan.TryParse(waitTime, out var time))
            {
                return time;
            }

            return TimeSpan.FromMinutes(5);
        });

        /// <summary> The docker environment variable for <see cref="RateLimitPerRoundCount"/>. </summary>
        private static Lazy<int> envRateLimitPerRoundCount = new Lazy<int>(() =>
        {
            var perRoundCount = Environment.GetEnvironmentVariable("RATE_LIMIT_PER_ROUND_COUNT");
            if (!string.IsNullOrWhiteSpace(perRoundCount) && int.TryParse(perRoundCount, out var value))
            {
                return value;
            }

            return 20;
        });

        /// <summary> The docker environment variable for <see cref=""/>. </summary>
        private static Lazy<EmailProtocol> envEmailProtocol = new Lazy<EmailProtocol>(() =>
        {
            var emailProtocol = Environment.GetEnvironmentVariable("EMAIL_PROTOCOL");
            if (Enum.TryParse<EmailProtocol>(emailProtocol, out var protocol))
            {
                return protocol;
            }

            return EmailProtocol.POP3;
        });

        /// <summary> The docker environment variable for <see cref=""/>. </summary>
        private static Lazy<string> envIMAPFolder = new Lazy<string>(() => {
            var folder = Environment.GetEnvironmentVariable("IMAP_FOLDER");
            if(!string.IsNullOrWhiteSpace(folder))
            {
                return folder;
            }

            return "INBOX";
        });

        /// <summary> The docker environment variable for <see cref="LogLevel"/>. </summary>
        private static Lazy<string> envLogLevel = new Lazy<string>(() =>
        {
            var logLevel = Environment.GetEnvironmentVariable("LOG_LEVEL");
            if (!string.IsNullOrWhiteSpace(logLevel))
            {
                return logLevel;
            }

            return "info";
        });

        /// <summary> The docker environment variable the minimum viable search score. </summary>
        private static Lazy<float> envMinSearchScore = new Lazy<float>(() =>
        {
            var minSearchScore = Environment.GetEnvironmentVariable("MIN_SEARCH_SCORE");
            if (!string.IsNullOrWhiteSpace(minSearchScore) && float.TryParse(minSearchScore, out var value))
            {
                return value;
            }

            return 0.2f;
        });

        /// <summary> The docker environment variable for <see cref="WebOnly"/>. </summary>
        private static Lazy<bool> envWebOnly = new Lazy<bool>(() =>
        {
            var webOnly = Environment.GetEnvironmentVariable("WEB_ONLY");

            if (bool.TryParse(webOnly, out var parsedBool))
            {
                return parsedBool;
            }
            else if (int.TryParse(webOnly, out var parsedInt))
            {
                return parsedInt != 0;
            }

            return false;
        });

        /// <summary> The docker environment variable for <see cref="WebUnsubscribe"/>. </summary>
        private static Lazy<bool> envWebUnsubscribe = new Lazy<bool>(() =>
        {
            var webUnsubscribe = Environment.GetEnvironmentVariable("WEB_UNSUBSCRIBE");

            if (bool.TryParse(webUnsubscribe, out var parsedBool))
            {
                return parsedBool;
            }
            else if (int.TryParse(webUnsubscribe, out var parsedInt))
            {
                return parsedInt != 0;
            }

            return false;
        });

        /// <summary> The docker environment variable for <see cref=""/>. </summary>
        private static Lazy<bool> envWebUseHTTPS = new Lazy<bool>(() =>
        {
            var webUseHTTPS = Environment.GetEnvironmentVariable("WEB_USE_HTTPS");

            if (bool.TryParse(webUseHTTPS, out var parsedBool))
            {
                return parsedBool;
            }
            else if (int.TryParse(webUseHTTPS, out var parsedInt))
            {
                return parsedInt != 0;
            }

            return false;
        });

        /// <summary> The docker environment variable for <see cref="WebExternalURL"/>. </summary>
        private static Lazy<string> envWebExternalURL = new Lazy<string>(() =>
        {
            var webExternalUrl = Environment.GetEnvironmentVariable("WEB_EXTERNAL_URL");

            if (!string.IsNullOrWhiteSpace(webExternalUrl))
            {
                return webExternalUrl;
            }

            return "http://example.com";
        });

        /// <summary> The docker environment variable for <see cref="Language"/>. </summary>
        private static Lazy<Language> envLanguage = new Lazy<Language>(() =>
        {
            var language = Environment.GetEnvironmentVariable("LANGUAGE");

            if(!string.IsNullOrWhiteSpace(language)) 
            {
                return LanguageHelper.GetLanguage(language);
            }

            return LanguageHelper.GetDefaultLanguage();
        });

        /// <summary> The docker environment variable for <see cref="WebSecret"/>. </summary>
        private static Lazy<string> envWebSecret = new Lazy<string>(() =>
        {
            var webSecret = Environment.GetEnvironmentVariable("WEB_SECRET");

            if(string.IsNullOrWhiteSpace(webSecret))
            {
                // If the web secret token is blank, generate a new one
                // and set the value.

                webSecret = Guid.NewGuid().ToString();
                Environment.SetEnvironmentVariable("WEB_SECRET", webSecret);
            }

            if(!string.IsNullOrWhiteSpace(webSecret))
            {
                return webSecret;
            }

            throw new ArgumentOutOfRangeException(nameof(webSecret));
        });

        #endregion

        #region Properties

        /// <summary> Gets the time between fetching email from the remote server. </summary>
        /// <remarks> The default value is <c>5:00</c>. </remarks>
        /// <value> The fetch time. </value>
        public static TimeSpan FetchTime
        {
            get => envFetchTime.Value;
        }

        /// <summary> Gets the time between rounds sending email messages. </summary>
        /// <remarks> The default value is <c>5:00</c>. </remarks>
        /// <value> The wait time between rounds. </value>
        public static TimeSpan RateLimitRoundWaitTime
        {
            get => envRateLimitRoundWait.Value;
        }

        /// <summary> Gets the of queued emails that can be sent in one round. </summary>
        /// <remarks> The default value is <c>20</c>. </remarks>
        /// <value> The number of emails to be sent per round. </value>
        public static int RateLimitPerRoundCount
        {
            get => envRateLimitPerRoundCount.Value;
        }

        /// <summary> Gets the email protocol to be used by <see cref="EmailClientWrapper"/>. </summary>
        /// <remarks> The default value is <c>POP3</c>. </remarks>
        /// <value> The email protocol. </value>
        public static EmailProtocol EmailProtocol
        {
            get => envEmailProtocol.Value;
        }

        /// <summary>
        /// Gets the pathname of the IMAP folder used by the <see cref="EmailClientWrapper"/> when <see cref="EmailProtocol"/>
        /// is <see cref="EmailProtocol.IMAP"/>.
        /// </summary>
        /// <remarks> The default value is <c>INBOX</c>. </remarks>
        /// <value> The pathname of the IMAP folder. </value>
        public static string IMAPFolder
        {
            get => envIMAPFolder.Value;
        }

        /// <summary> Gets the verbosity level with which to log application events. </summary>
        /// <remarks> The default value is <c>info</c>. </remarks>
        /// <value> The log level. </value>
        /// <seealso cref="NLog.LogLevel"/>
        /// <seealso cref="Common.NLogConfiguration"/>
        public static string LogLevel
        {
            get => envLogLevel.Value;
        }

        /// <summary> Gets the minimum viable search score. </summary>
        /// <remarks> The default value is <c>0.2f</c>. </remarks>
        /// <value> The minimum viable search score. </value>
        /// <seealso cref="Common.SearchResult{T}"/>
        /// <seealso cref="Common.SearchCache{T}"/>
        public static float MinimumSearchScore
        {
            get => envMinSearchScore.Value;
        }

        /// <summary>
        /// Gets a value that if set, only the web interface will be initialized. <see cref="Microsoft.Extensions.Hosting.BackgroundService">
        /// Background worker threads</see> will not be initialized.
        /// </summary>
        /// <remarks> The default value is <see langword="false"/>. </remarks>
        /// <value>
        /// True if only the web interface will be initialized, false if <see cref="Microsoft.Extensions.Hosting.BackgroundService">
        /// background service threads</see> will also be initialized.
        /// </value>
        public static bool WebOnly
        {
            get => envWebOnly.Value;
        }

        /// <summary>
        /// Gets a value indicating whether the an externally accessable unsubscription link is
        /// supported. If set to <see langword="true"/>, messages will replace the unsubscribe link with
        /// a link pointing toward <see cref=""/>.
        /// </summary>
        /// <remarks> The default value is <see langword="true"/> </remarks>
        /// <value> True if an externally accessable port is exposed, false otherwise. </value>
        public static bool WebUnsubscribe
        {
            get => envWebUnsubscribe.Value;
        }

        /// <summary>
        /// Gets a value indicating whether the an externally accessable unsubscription link should
        /// assume HTTPS transport.
        /// </summary>
        /// <remarks> The default value is <see langword="true"/>. </remarks>
        /// <value> True if using HTTPS, false if not. </value>
        public static bool WebUseHTTPS
        {
            get => envWebUseHTTPS.Value;
        }

        /// <summary> Gets a URL used when creating an unsubscribe link. </summary>
        /// <remarks> The default value is <see langword="true"/>. </remarks>
        /// <value> The external base URL. </value>
        public static string WebExternalURL
        {
            get => envWebExternalURL.Value;
        }

        /// <summary> Gets the localization language. </summary>
        /// <value> The localization language. </value>
        public static Language Language
        {
            get => envLanguage.Value;
        }

        /// <summary> Gets the web secret. </summary>
        /// <value> The web secret. </value>
        public static string WebSecret
        {
            get => envWebSecret.Value;
        }

        #endregion
    }
}
