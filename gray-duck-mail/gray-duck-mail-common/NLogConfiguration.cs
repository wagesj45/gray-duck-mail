using NLog;
using NLog.Config;
using NLog.Filters;
using NLog.Layouts;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrayDuckMail.Common
{
    /// <summary> A static class that contains the <see cref="NLog.Config.LoggingConfiguration">NLog configuration</see>. </summary>
    public static class NLogConfiguration
    {
        /// <summary>
        /// Gets the NLog configuration configured to the given <paramref name="logLevel"/> and
        /// <paramref name="logFilePath"/>.
        /// </summary>
        /// <param name="logLevel">    The log level. </param>
        /// <param name="logFilePath"> Full pathname of the log file. </param>
        /// <returns> The NLog configuration. </returns>
        public static LoggingConfiguration GetConfiguration(string logLevel, string logFilePath)
        {
            var configuration = new LoggingConfiguration();
            var consoleTarget = new ColoredConsoleTarget();
            var fileTarget = new FileTarget();

            consoleTarget.UseDefaultRowHighlightingRules = true;
            fileTarget.FileName = logFilePath;

            configuration.AddRule(ParseLogLevel(logLevel), LogLevel.Fatal, consoleTarget);
            configuration.AddRule(ParseLogLevel(logLevel), LogLevel.Fatal, fileTarget);

            consoleTarget.Layout = "[${logger}] ${message} ${exception:format=tostring}";

            consoleTarget.RowHighlightingRules.Add(
                new ConsoleRowHighlightingRule()
                {
                    Condition = "level == LogLevel.Trace",
                    ForegroundColor = ConsoleOutputColor.DarkCyan
                });
            consoleTarget.RowHighlightingRules.Add(
                new ConsoleRowHighlightingRule()
                {
                    Condition = "level == LogLevel.Debug",
                    ForegroundColor = ConsoleOutputColor.Blue
                });
            consoleTarget.RowHighlightingRules.Add(
                new ConsoleRowHighlightingRule()
                {
                    Condition = "level == LogLevel.Info",
                    ForegroundColor = ConsoleOutputColor.Gray
                });
            consoleTarget.RowHighlightingRules.Add(
                new ConsoleRowHighlightingRule()
                {
                    Condition = "level == LogLevel.Warn",
                    ForegroundColor = ConsoleOutputColor.Yellow
                });
            consoleTarget.RowHighlightingRules.Add(
                new ConsoleRowHighlightingRule()
                {
                    Condition = "level == LogLevel.Error",
                    ForegroundColor = ConsoleOutputColor.Red
                });
            consoleTarget.RowHighlightingRules.Add(
                new ConsoleRowHighlightingRule()
                {
                    Condition = "level == LogLevel.Fatal",
                    ForegroundColor = ConsoleOutputColor.DarkRed,
                    BackgroundColor = ConsoleOutputColor.White
                });

            configuration.AddTarget("ColoredConsole", consoleTarget);
            configuration.AddTarget("File", fileTarget);

            return configuration;
        }

        /// <summary> Parses a string representation of a <see cref="LogLevel"/>. </summary>
        /// <remarks>
        /// If parsing fails, or an invalid value is given, a default value of
        /// <see cref="LogLevel.Info"/> is returned.
        /// </remarks>
        /// <param name="logLevel"> The string representation of log level. </param>
        /// <returns> The log level. </returns>
        private static LogLevel ParseLogLevel(string logLevel)
        {
            var result = LogLevel.Info;

            if(string.IsNullOrWhiteSpace(logLevel))
            {
                return result;
            }

            switch (logLevel.ToLowerInvariant())
            {
                case "all":
                case "trace":
                    result = LogLevel.Trace;
                    break;
                case "verbose":
                case "debug":
                    result = LogLevel.Debug;
                    break;
                case "info":
                case "information":
                    result = LogLevel.Info;
                    break;
                case "warn":
                case "warning":
                    result = LogLevel.Warn;
                    break;
                case "err":
                case "error":
                    result = LogLevel.Error;
                    break;
                case "fatal":
                    result = LogLevel.Fatal;
                    break;
                default:
                    result = LogLevel.Info;
                    break;
            }

            return result;
        }
    }
}
