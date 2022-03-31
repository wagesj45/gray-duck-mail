using System;
using System.Reflection;

namespace EasyMailDiscussion.Web
{
    /// <summary> Contains globally accessable application settings ready from appsettings.json. </summary>
    public static class ApplicationSettings
    {
        #region Members
        
        /// <summary> (Immutable) The database section name. </summary>
        public const string SECTION_DATABASE = "Database";
        /// <summary> (Immutable) The database path key name. </summary>
        public const string DATABASE_PATH = "Path";
        /// <summary> (Immutable) The log section name. </summary>
        public const string SECTION_LOG = "Log";
        /// <summary> (Immutable) The log path key name. </summary>
        public const string LOG_PATH = "Path";

        /// <summary> The lazily loaded application version. </summary>
        private static Lazy<string> applicationVersion = new Lazy<string>(() =>
        {
            return Assembly.GetEntryAssembly().GetName().Version.ToString();
        });

        #endregion

        #region Properties

        /// <summary> Gets or sets the full pathname of the database file. </summary>
        /// <value> The full pathname of the database file. </value>
        public static Uri DatabaseFilePath { get; set; }

        /// <summary> Gets or sets the full pathname of the log file. </summary>
        /// <value> The full pathname of the log file. </value>
        public static Uri LogFilePath { get; set; } 

        /// <summary> Gets the application version as a string. </summary>
        /// <value> The application version. </value>
        public static string ApplicationVersion
        {
            get
            {
                return applicationVersion.Value;
            }
        }

        #endregion
    }
}
