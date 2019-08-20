/*
 * Project:         Telegram Messenger Client Application
 * Description:     This application is used to test the TLSharp Library
 *                  It sends text messages to a Telegram and a Telegram Channel.
 *                  It also sends an image to a Telegram User
 * 
 * Author:  Sheldon Reddy
 * Date:    20190820
 * 
 * Dependencies: TLSharp [ Nuget> Install-Package TLSharp ]
 * 
 * Resources
 *  https://github.com/sochix/TLSharp [Shows how to perform functions not in the list as well]
 *  https://github.com/sochix/TLSharp/blob/master/TLSharp.Tests/TLSharpTests.cs#L107
 *  https://my.telegram.org/apps
 * 
 * IMPORTANT    - Add your custom apiId and apiHash to run the program - This is found in the Globals Region
 *              - Before Proceeding, read each message to find the instructions - pretty simple
 *              - You only need to AUTH the User once. 
 *      
 * STATUS: COMPLETED           
 *              
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

namespace TelegramMessengerClient
{
    public partial class Form1 : Form
    {

        #region Globals
        private TelegramClient client;
        // Change these values to your own custom values obtained from https://my.telegram.org/apps
        private int apiId = 0;
        private string apiHash = "";
        private string destNumber = "27829410963";
        private string sourceNumber = "+27739993081";
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        /// <summary>
        ///     CONNECT_CLICK Connect the Telegram Client to the Telegram Service to 
        ///     allow the C# application to perform typical Messaging Functions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Connect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TelegramClient(apiId, apiHash);
                await client.ConnectAsync();
                listBox1.Items.Add("Connected");
            }
            catch(Exception ex)
            {
                listBox1.Items.Add("Exception: "+ex.ToString());
            }
            
        }


        /// <summary>
        ///     AUTHENTICATE_CLICK is responsible for Authenticating the User ( using Cell Number )
        ///     to allow the C# Application to perform all Messaging functions ( Only Authenticated users can perform all functions)
        ///     See https://core.telegram.org/api/auth to see what Function Non-Auth Users can perform.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Authenticate_Click(object sender, EventArgs e)
        {
            try
            {
                var hash = await client.SendCodeRequestAsync(sourceNumber);

                // Check your phone for the Code Sent by Telegram, 
                // Enter it below, Remove the debug breakpoint and re-run
                var code = "48097";

                var user = await client.MakeAuthAsync(sourceNumber, hash, code);

                if(user!=null)
                {
                    listBox1.Items.Add("User Authenticated for: "+ sourceNumber);
                }
               
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Exception: " + ex.ToString());
            }
            
        }


        /// <summary>
        ///     MESSAGE_CLICK sends a text message to a Telegram User found in the contact list of the Authenticated User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void message_Click(object sender, EventArgs e)
        {
            try
            {
                //get available contacts
                var result = await client.GetContactsAsync();

                //find recipient in contacts
                var user = result.Users
                    .Where(x => x.GetType() == typeof(TLUser))
                    .Cast<TLUser>()
                    .FirstOrDefault(x => x.Phone == destNumber);

                if (user == null)
                {
                    throw new System.Exception("Number was not found in Contacts List of user: " + sourceNumber);
                }

                //send message
                await client.SendMessageAsync(new TLInputPeerUser() { UserId = user.Id }, "Hello World!");
                listBox1.Items.Add("Message Sent to: " + destNumber);
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Exception: " + ex.ToString());
            }
            
        }


        /// <summary>
        ///     BUTTON4_CLICK Sends a text message to a Telegram Channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {

                var ret = await client.GetUserDialogsAsync();

                // NB. The following TLDIAGLOSLICE Casting doesn't work so I manually browsed the ret for the chat.ID and AccessHash values
                //get user dialogs
                //var dialogs = (TLDialogsSlice)await client.GetUserDialogsAsync();

                //find channel by title
                //var chat = dialogs.Chats
                //  .Where(c => c.GetType() == typeof(TLChannel))
                //  .Cast<TLChannel>()
                //  .FirstOrDefault(c => c.Title == "DIGNOSTM");

                // Send message
                // BEFORE PROCEEDING - Add a watch to "ret" above and manually inspect the chat.Id and AccessHash fields for your desired Channel and add it below.
                // Then remove breakpoint and re-run.
                await client.SendMessageAsync(new TLInputPeerChannel() { ChannelId = 00000/*chat.Id*/, AccessHash = 000000 /*chat.AccessHash.Value*/ }, "Hello World!");
                listBox1.Items.Add("Message Sent to: " + "XXXXX Channel");
                
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Exception: " + ex.ToString());
            }
            
        }


        /// <summary>
        ///     IMAGESEND_CLICK Sends a JPG Image to a Telegram User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ImageSend_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await client.GetContactsAsync();

                var user = result.Users
                    .OfType<TLUser>()
                    .FirstOrDefault(x => x.Phone == destNumber);

                // Enter Image Title and ImageLocation before proceeding
                var fileResult = (TLInputFile)await client.UploadFile("Image Title", new StreamReader(@"FullImageLocation"));
                await client.SendUploadedPhoto(new TLInputPeerUser() { UserId = user.Id }, fileResult, "DIGNOSTM");
                listBox1.Items.Add("Image Sent to: " + destNumber);
            }
            catch(Exception ex)
            {
                listBox1.Items.Add("Exception: " + ex.ToString());
            }
            
        }
    }
}
