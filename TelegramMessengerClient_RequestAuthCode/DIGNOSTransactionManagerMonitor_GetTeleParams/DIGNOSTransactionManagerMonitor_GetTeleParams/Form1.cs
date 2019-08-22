using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Telegram
using TeleSharp.TL;
using TeleSharp.TL.Messages;
using TLSharp.Core;
using TLSharp.Core.Network;
using TLSharp.Core.Requests;
using TLSharp.Core.Utils;

namespace DIGNOSTransactionManagerMonitor_GetTeleParams
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region WinControls Init
            cellTB.Text = "+27829410963";
            APIIDTB.Text = "963585";
            APIHashTB.Text = "6d6925c728ef9e4f3bdaf8526131ec9c";
            ChannelNameTB.Text = "DIGNOSTM_MPCDEV";
            #endregion
        }

        private Indexers.TelegramInfo TeleSesh = new Indexers.TelegramInfo();
        private async void AuthClientBTN_Click(object sender, EventArgs e)
        {

            #region Telegram Client Session Parameters
            try
            {
                TeleSesh.SourceNumber = cellTB.Text;
                TeleSesh.ApiId = Int32.Parse(APIIDTB.Text);
                TeleSesh.ApiHash = APIHashTB.Text;
            }
            catch(Exception ex)
            {
                Logging.Logger.Exception(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            
            
            #endregion

            #region Client Connection
            try
            {
                TeleSesh.Client = new TelegramClient(TeleSesh.ApiId, TeleSesh.ApiHash);
                await TeleSesh.Client.ConnectAsync();
                Logging.Logger.Info("Telegram Client Connected", System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                Logging.Logger.Exception(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                MessageBox.Show("Telegram Client Connection Error" +
                                "\nPlease ensure you entered the information correctly.",
                                "Telegram Client Connection",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

            }
            #endregion

            #region  Client Authentication Code Request
            try
            {
                
                TeleSesh.AuthHash = await TeleSesh.Client.SendCodeRequestAsync(TeleSesh.SourceNumber);

                Logging.Logger.Info("Authentication Code Requested",System.Reflection.MethodBase.GetCurrentMethod().Name);

                MessageBox.Show("Authentication Code has been Requested, Please check your Telegram App", 
                                "Authentication Code Request", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                Logging.Logger.Exception(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);

                MessageBox.Show("There was an error requesting your Authentication Code." +
                                "\nPlease ensure you entered the information correctly.", 
                                "Authentication Code Request", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Exclamation);
            }

            #endregion
            
        }

        private async void ConnectTB_Click(object sender, EventArgs e)
        {

            #region Telegram Client Session Parameters
            try
            {
                TeleSesh.SourceNumber = cellTB.Text;
                TeleSesh.ApiId = Int32.Parse(APIIDTB.Text);
                TeleSesh.ApiHash = APIHashTB.Text;
            }
            catch (Exception ex)
            {
                Logging.Logger.Exception(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            #endregion

            #region Client Connection
            try
            {
                TeleSesh.Client = new TelegramClient(TeleSesh.ApiId, TeleSesh.ApiHash);
                await TeleSesh.Client.ConnectAsync();
                Logging.Logger.Info("Telegram Client Connected", System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                Logging.Logger.Exception(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                MessageBox.Show("Telegram Client Connection Error" +
                                "\nPlease ensure you entered the information correctly.",
                                "Telegram Client Connection",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

            }
            #endregion
        }

        private async void AuthClntBTN_Click(object sender, EventArgs e)
        {
            #region Authenticate Client
            TeleSesh.AuthCode = AuthCodeTB.Text;

            var user = await TeleSesh.Client.MakeAuthAsync(TeleSesh.SourceNumber, TeleSesh.AuthHash, TeleSesh.AuthCode);

            if (user != null)
            {
                Logging.Logger.Info("Client Authentication Success", System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            else
            {
                Logging.Logger.Error("Client Authentication Failed", System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            #endregion
        }

        private async void ProcessBTN_Click(object sender, EventArgs e)
        {

            #region Channel Parameters
            TeleSesh.ChannelName = ChannelNameTB.Text;

            try
            {

                var dialogs = await TeleSesh.Client.GetUserDialogsAsync() as TLDialogs;

                //find channel by title
                var chat = dialogs.Chats
                  .Where(c => c.GetType() == typeof(TLChannel))
                  .Cast<TLChannel>()
                  .FirstOrDefault(c => c.Title == TeleSesh.ChannelName);


                await TeleSesh.Client.SendMessageAsync(new TLInputPeerChannel() { ChannelId = chat.Id, AccessHash = chat.AccessHash.Value }, "Hello World!");
                Logging.Logger.Info("Test Message Sent", System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
            catch (Exception ex)
            {
                Logging.Logger.Exception(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            #endregion

        }

        
    }
}
