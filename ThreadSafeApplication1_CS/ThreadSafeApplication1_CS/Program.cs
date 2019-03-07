/*
 *  This program uses the AUTORESETEVENT to implement a thread safe application.
 *
 *  The AUTORESETEVENT is an alternative to Locking or Monitoring.
 *
 *  see https://www.c-sharpcorner.com/article/introduction-to-multithreading-in-C-Sharp/
 *
 *  Sheldon Reddy
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// For Multi-Threading
using System.Threading;

namespace ThreadSafeApplication1_CS
{
    class Program
    {

        #region Thread Config
        // Construct two threads for two processes 
        private static Thread thread1 = new Thread(new ThreadStart(Thread1Fcn));
        private static Thread thread2 = new Thread(new ThreadStart(Thread2Fcn));

        // AutoResetEvent for each thread
        private static AutoResetEvent _blockThread1 = new AutoResetEvent(false);
        private static AutoResetEvent _blockThread2 = new AutoResetEvent(true);

        // ThreadProceed Variable
        private static bool _stopThreads = false;

        #endregion

        
        #region Thread 1
        private static void Thread1Fcn()
        {
            while (_stopThreads == false)
            {
                // Block Thread 1 while Thread 2 is executing  
                _blockThread1.WaitOne();
                // Delay
                Thread.Sleep(1000); 
                // Output to Console
                Console.WriteLine(" Hello from Thread 1");
                //Unblock Thread 2
                _blockThread2.Set();
            }
        }
        #endregion

        #region Thread 2
        private static void Thread2Fcn()
        {
            while (_stopThreads == false)
            {
                //Block Thread 1 whilst Thread 2 is executing
                _blockThread2.WaitOne();
                // Delay
                Thread.Sleep(1000);    
                // Output to Console
                Console.WriteLine("Hello from Thread 2 ");
                // Ublock Thread1 
                _blockThread1.Set();
            }
        }
        #endregion

        #region Stop Threading
        private static void stop_Threads()
        {
            _stopThreads = true;
        }
        #endregion



        #region Main Entry Point
        static void Main(string[] args)
        {
            // Execute the threads 
            thread1.Start();
            thread2.Start();
        }
        #endregion

    }

}
