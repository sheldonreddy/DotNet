/*
 * Trace Listener Logger 
 *  Directs the trace output to an appropriate target.
 *   Log File Path: ...\TraceListenerLogger_CS\bin\Debug
 *
 *  
 * Component
 *  - XXX
 *  
 * Dependencies
 *  - System.Diagnostics 
 *  - App.Config file must be edited to include Lines 6-12
 * 
 * Test 
 *  - XXX
 *  
 * Functionality
 *  - Log timestamped trace output to file  
 * 
 * Version Control
 *  - Github: https://bit.ly/2ALJuwD
 *  - [develop / developWork / opcdaconnector]
 * 
 * Revision:    0.1
 * Date:        20190117
 * Dev:         Sheldon Reddy
 * 
 * Src: https://bit.ly/2W0rZ4J
 */


#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Required to access the Trace.xxx functions
using System.Diagnostics;

#endregion

namespace TraceListenerLogger_CS
{

    #region Logger Class
    public static class Logger
    {
        public static void Error(string message, string module)
        {
            WriteEntry(message, "error", module);
        }

        public static void Error(Exception ex, string module)
        {
            WriteEntry(ex.Message, "error", module);
        }

        public static void Warning(string message, string module)
        {
            WriteEntry(message, "warning", module);
        }

        public static void Info(string message, string module)
        {
            WriteEntry(message, "info", module);
        }

        private static void WriteEntry(string message, string type, string module)
        {
            Trace.WriteLine(
                    string.Format("{0},{1},{2},{3}",
                                  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                  type,
                                  module,
                                  message));
        }
    }
    #endregion


    #region Program Class
    class Program
    {
        static void Main(string[] args)
        {

            #region Invoke the TraceLogger Class
            try
            {
                Logger.Info("Application started.", "MyApp");
                Logger.Info("Processing...", "MyApp");
                Logger.Warning("Application about to exit!", "MyApp");
                Logger.Info("Application finished.", "MyApp");

                throw new Exception();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "MyApp");
            }
            #endregion

        }
    }
    #endregion

}
