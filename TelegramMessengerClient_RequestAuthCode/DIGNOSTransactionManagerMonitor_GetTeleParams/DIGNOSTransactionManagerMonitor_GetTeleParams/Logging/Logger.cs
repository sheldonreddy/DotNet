using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DIGNOSTransactionManagerMonitor_GetTeleParams.Logging
{
    /// <summary>
    ///     TRACELOGGING Functionality
    /// </summary>
    public class Logger
    {

        public static void Error(string message, string module)
        {
            WriteEntry(message, "ERRR", module);
        }

        public static void Exception(Exception ex, string module)
        {
            WriteEntry(ex.Message, "EXCP", module);
        }

        public static void Warning(string message, string module)
        {
            WriteEntry(message, "Warn", module);
        }

        public static void Process(string message, string module)
        {
            WriteEntry(message, "Proc", module);
        }

        public static void Info(string message, string module)
        {
            WriteEntry(message, "Info", module);
        }

        public static void LineBreak(string lineBreak)
        {
            System.Diagnostics.Trace.WriteLine(
                    string.Format("{0}", lineBreak));
        }

        private static void WriteEntry(string message, string type, string module)
        {
            System.Diagnostics.Trace.WriteLine(
                    string.Format("{0} \t{1} \t{2} | {3}",
                                  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                  type,
                                  module,
                                  message));
        }

    }
}
