using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
// Timers
using System.Timers;
// Kepware
using Kepware.ClientAce.OpcDaClient;
using Kepware.ClientAce.OpcCmn;
// OPCDA Connector
using OPCDAStackWrapper;
// Classes
//
using System.IO;
using ArithemeticWinService_CS.Classes;

namespace ArithemeticWinService_CS
{
    public partial class Service1 : ServiceBase
    {

        // Initialise a timer
        Timer timer = new Timer(); // name space(using System.Timers;)  

        // Server Index
        public List<ServerIndex> servInd = new List<ServerIndex>();
        public List<string> locServInd = new List<string>();

        public string sPath = "D:\\Dir\\DIGNOS\\serverList.csv";

        public double counter = 0;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            ServerList();

            // Create an event
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 5000; //number in milisecinds  
            timer.Enabled = true;
        }

        protected override void OnStop()
        {

        }

        public int ReturnValue()
        {
            return Program.retVar;
        }

        public void ServerList()
        {
            System.IO.File.WriteAllText(@sPath, "");


            // Config Discovery Params
            string nodeName = "localhost";
            bool returnAllServers = false; // false = returns only DA Servers

            // Instantiate OPCEnum Object
            OpcServerEnum opcEnum = new OpcServerEnum();

            // Type of OPC Servers to search for 
            ServerCategory[] serverCategories = new ServerCategory[1];
            serverCategories[0] = new ServerCategory();
            serverCategories[0] = ServerCategory.OPCDA;

            // Used to store the servers identified during discovery
            ServerIdentifier[] servers;

            // Perform Discovery
            opcEnum.EnumComServer(nodeName, returnAllServers, serverCategories, out servers);

            // Evaluate each Server
            foreach (ServerIdentifier server in servers)
            {
                // Prevent Duplicates from being added to the List
                if (locServInd.Count == 0 || !locServInd.Contains(server.ProgID))
                {
                    // Add details to Server Index
                    servInd.Add(new ServerIndex
                    {
                        ProgID = server.ProgID, Hostname = server.HostName, Category = server.Category,
                        CLSID = server.CLSID, Url = server.Url
                    });
                    locServInd.Add(server.ProgID);
                }
            }

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);

            for (int i = 0; i < locServInd.Count; i++)
            {
                SaveFile.WriteLine(locServInd[i] + "," + counter + " ");
            }

            SaveFile.Close();

            counter++;
        }

    
      


    #region Timer Event-Handler
        // Timer Event-Handler
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
         
            ServerList();

        }

        #endregion

    }
}
