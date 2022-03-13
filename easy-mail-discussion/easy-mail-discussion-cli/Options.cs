using CommandLine;
using System;
using System.IO;

namespace EasyMailDiscussion.Cli
{
    public class Options
    {
        #region Properties

        /// <summary> Gets or sets the full pathname of the database file. </summary>
        /// <value> The full pathname of the database file. </value>
        [Option('d', "db", Required = false, HelpText = "The path to a SQLite database file.")]
        public Uri DBPath { get; set; }

        #endregion

        #region Contructors

        /// <summary> Default constructor. </summary>
        /// <remarks> This constructor initializes some default values that must be evaluated at runtime, since CommandLineParser decorators can only generate static default values. </remarks>
        public Options()
        {
            //Set the defaults for runtime evaluated paths here.
            var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var dbPath = Path.Combine(appDataFolder, "easymaildiscussion.db");
        }

        #endregion
    }
}