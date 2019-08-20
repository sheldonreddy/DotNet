using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
// Timers
using System.Timers;
// File
using System.IO;
// Service Status
using System.Runtime.InteropServices;

namespace windowsService
{
    public partial class Service1 : ServiceBase
    {

        #region Service Status
        // Services report their status to the Service Control Manager,
        // so that users can tell whether a service is functioning correctly.
        // By default, services that inherit from ServiceBase report a limited
        // set of status settings, including Stopped, Paused, and Running.
        // If a service takes a little while to start up, it might be helpful
        // to report a Start Pending status. You can also implement the Start
        // Pending and Stop Pending status settings by adding code that calls
        // into the Windows SetServiceStatus function.
        public enum ServiceState
        {
            SERVICE_STOPPED = 0x00000001,
            SERVICE_START_PENDING = 0x00000002,
            SERVICE_STOP_PENDING = 0x00000003,
            SERVICE_RUNNING = 0x00000004,
            SERVICE_CONTINUE_PENDING = 0x00000005,
            SERVICE_PAUSE_PENDING = 0x00000006,
            SERVICE_PAUSED = 0x00000007,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceStatus
        {
            public int dwServiceType;
            public ServiceState dwCurrentState;
            public int dwControlsAccepted;
            public int dwWin32ExitCode;
            public int dwServiceSpecificExitCode;
            public int dwCheckPoint;
            public int dwWaitHint;
        };


        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(System.IntPtr handle, ref ServiceStatus serviceStatus);

        #endregion

        // Initialise a timer
        Timer timer = new Timer(); // name space(using System.Timers;)  

        public Service1()
        {
            InitializeComponent();

        }

        #region StartService

        //Start the service
        protected override void OnStart(string[] args)
        {

            #region ServiceStatus [StartPendingService]
            // Update the service state to Start Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
            #endregion


            // Create an event
            WriteToFile("Service is started at " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 5000; //number in milisecinds  
            timer.Enabled = true;


            #region ServiceStatus [RunPendingService]
            // Update the service state to Running.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
            #endregion

        }
        #endregion

        #region StopService

        // Stop the Service
        protected override void OnStop()
        {
            WriteToFile("Service is stopped at " + DateTime.Now);
        }
        #endregion

        // NB. Service actions can be extended to: [ OnPause, OnContinue, and OnShutdown ]
        // in the same way it was done for [ onService and onStop ] above.

        #region Timer Event-Handler
        // Timer Event-Handler
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            WriteToFile("Service is recall at " + DateTime.Now);
        }

        #endregion

        #region Helper Functions

        // Helper functions
        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
        #endregion
    }
}
