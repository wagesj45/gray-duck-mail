using NLog;
using NLog.Config;
using NLog.Filters;
using NLog.Layouts;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMailDiscussion.Common
{
    /// <summary> A static class that retrieves the <see cref="LoggingConfiguration">NLog configuration</see>. </summary>
    public static class NLogConfiguration
    {
        /// <summary> Gets the NLog configuration. </summary>
        /// <param name="logLevel"> The log level. </param>
        /// <returns> The configuration. </returns>
        public static LoggingConfiguration GetConfiguration(string logLevel, string logFilePath)
        {
            var configuration = new LoggingConfiguration();
            var consoleTarget = new ColoredConsoleTarget();
            var fileTarget = new FileTarget();

            consoleTarget.UseDefaultRowHighlightingRules = true;
            fileTarget.FileName = logFilePath;

            configuration.AddRule(GetLogLevel(logLevel), LogLevel.Fatal, consoleTarget);
            configuration.AddRule(GetLogLevel(logLevel), LogLevel.Fatal, fileTarget);

            consoleTarget.Layout = "[Easy-Email-Discussion] ${message} ${exception:format=tostring}";

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

        /// <summary> Gets log level. </summary>
        /// <param name="logLevel"> The log level. </param>
        /// <returns> The log level. </returns>
        private static LogLevel GetLogLevel(string logLevel)
        {
            var result = LogLevel.Info;

            switch (logLevel.ToLowerInvariant())
            {
                case "trace":
                    result = LogLevel.Trace;
                    break;
                case "debug":
                    result = LogLevel.Debug;
                    break;
                case "info":
                    result = LogLevel.Info;
                    break;
                case "warn":
                case "warning":
                    result = LogLevel.Warn;
                    break;
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
