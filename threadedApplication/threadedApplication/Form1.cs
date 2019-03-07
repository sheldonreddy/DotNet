/*
 * This application is a THREADSAFE application which shares a WINDOWS FORMS CONTROL
 * 
 * To share a control, as opposed to a memory resource, it requires either
 * 
 *      1. Invoke Method with a Delegate, or,
 *      2. Background Worker
 *      
 *      Nb. Define/undef USEINVOKEDELEGATE to test either of these
 *      
 * Sheldon Reddy
 * 20190307
 * 
 * see https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls
*/

#region PROGRAM CONTROL
//#define USEINVOKEDELEGATE
#undef USEINVOKEDELEGATE
#endregion

#region Namespaces
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
#endregion

namespace threadedApplication
{
    public partial class Form1 : Form
    {
        private delegate void SafeCallDelegate(string text);

        // Form Initalise
        public Form1()
        {
            InitializeComponent();
        }

        // Form Load Control
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Thread Safe Calls to Windows Form Control 

#if USEINVOKEDELEGATE

        #region INVOKEMETHODWITHDELEGATE
        private void start_Click(object sender, EventArgs e)
        {
            // Create Threads
            Thread thread1 = new Thread(new ThreadStart(thread1Fcn));
            Thread thread2 = new Thread(new ThreadStart(thread2Fcn));

            // Start Thread
            thread1.Start();
            thread2.Start();

            // Delay Thread
            Thread.Sleep(1000);
        }

        private void WriteTextSafe(string text)
        {
            // If the control is being used
            if (output.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                Invoke(d, new object[] { text });
            }
            else
            {// If control is free
                output.Text = text;
            }
        }

        private void thread1Fcn()
        {
            WriteTextSafe("Hello from thread 1");
            Console.WriteLine("Thread1");

        }


        private void thread2Fcn()
        {
            WriteTextSafe("Hello from thread 2");
            Console.WriteLine("Thread2");
        }

        #endregion

#else

        #region BACKGROUNDWORKER
        // Globals
        private BackgroundWorker backgroundWorker;
        private BackgroundWorker backgroundWorker1;
        private Thread thread2 = null;
        private Thread thread1 = null;

        private void start_Click(object sender, EventArgs e)
        {
            // First BW Thread
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
            backgroundWorker.RunWorkerAsync();

            // Second BW Thread
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += new DoWorkEventHandler(BackgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted1);
            backgroundWorker1.RunWorkerAsync();

        }


        #region First BW Thread
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            thread2 = new Thread(new ThreadStart(backgroundWorker.RunWorkerAsync));
            Thread.Sleep(100);
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            output.Text = "BW Thread 1";
            Console.WriteLine("BW Thread 1");
        }
        #endregion

        #region Second BW Thread
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            thread1 = new Thread(new ThreadStart(backgroundWorker1.RunWorkerAsync));
            Thread.Sleep(100);
        }

        private void BackgroundWorker_RunWorkerCompleted1(object sender, RunWorkerCompletedEventArgs e)
        {
            output.Text = "BW Thread 2";
            Console.WriteLine("BW Thread 2");
        }
        #endregion


        #endregion
#endif
    }
}
