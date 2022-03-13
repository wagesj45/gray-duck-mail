using CommandLine;
using NLog;
using System;

namespace EasyMailDiscussion.Cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(options =>
            {
                Logger l = LogManager.GetCurrentClassLogger();
            });
        }
    }
}
