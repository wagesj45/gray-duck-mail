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

        /// <summary> Size of the environment variable for <see cref="PageSize"/>. </summary>
        private static Lazy<int> envPageSize = new Lazy<int>(() =>
        {
            var pageSize = Environment.GetEnvironmentVariable("PAGE_SIZE");

            if(int.TryParse(pageSize, out var page))
            {
                return page;
            }

            return 10;
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

        /// <summary> Gets the page size to use when paginating results. </summary>
        /// <value> The size of the page. </value>
        public static int PageSize
        {
            get => envPageSize.Value;
        }

        #endregion
    }
}
