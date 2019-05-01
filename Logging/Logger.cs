using System;

namespace Logging
{
    /* TODO: Turn this into a full fledged logger later on. Support for writing to a file or a DB table to be added. Multithreaded logging to be supported */
    public class Logger
    {
        public enum LogLevel
        {
            LL_CRITICAL, LL_ERROR, LL_DEBUG, LL_INFO
        }
        public static void AddLog(string logMsg, string file = "", string functionName = "", int lineNumber = 0, LogLevel logLevel = LogLevel.LL_INFO)
        {
            string log = file + "::" + functionName + "::" + lineNumber.ToString() + ": " + logMsg; // TODO: Use the log level to route the logs appropriately
            Console.WriteLine(log);
        }
    }
}
