using System;

namespace EasyMailDiscussion.Web
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

        /// <summary> The docker environment variable for <see cref="LogLevel"/>. </summary>
        private static Lazy<string> envLogLevel = new Lazy<string>(() =>
        {
            var logLevel = Environment.GetEnvironmentVariable("LOG_LEVEL");
            if(!string.IsNullOrWhiteSpace(logLevel))
            {
                return logLevel;
            }

            return "info";
        });

        /// <summary>
        /// If set, only the web interface will be initialized. <see cref="Microsoft.Extensions.Hosting.BackgroundService">
        /// Background worker threads</see> will not be initialized.
        /// </summary>
        private static Lazy<bool> envWebOnly = new Lazy<bool>(() =>
        {
            var webOnly = Environment.GetEnvironmentVariable("WEB_ONLY");

            if(bool.TryParse(webOnly, out var parsedBool))
            {
                return parsedBool;
            }
            else if(int.TryParse(webOnly, out var parsedInt))
            {
                return parsedInt != 0;
            }

            return false;
        });

        #endregion

        #region Properties

        /// <summary> Gets the time between fetching email from the remote server. </summary>
        /// <value> The fetch time. </value>
        public static TimeSpan FetchTime
        {
            get => envFetchTime.Value;
        }

        /// <summary> Gets the verbosity level with which to log application events. </summary>
        /// <value> The log level. </value>
        public static string LogLevel
        {
            get => envLogLevel.Value;
        }

        /// <summary>
        /// Gets a value that if set, only the web interface will be initialized. <see cref="Microsoft.Extensions.Hosting.BackgroundService">
        /// Background worker threads</see> will not be initialized.
        /// </summary>
        /// <value>
        /// True if only the web interface will be initialized, false if <see cref="Microsoft.Extensions.Hosting.BackgroundService">
        /// background service threads</see> will also be initialized.
        /// </value>
        public static bool WebOnly
        {
            get => envWebOnly.Value;
        }

        #endregion
    }
}
