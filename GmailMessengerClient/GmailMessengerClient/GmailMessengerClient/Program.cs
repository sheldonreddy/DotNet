using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Add EASendMail namespace
using EASendMail;

/*README
 *      You must turn-on the setting on your GMAIL account to allow less secure apps to access your GMAIL Account (the sender)

 * Dependencies: Nuget> Install-Package EASendMail
 * 
 * Check Nuget Output to find the path for "Adding package 'EASendMail.7.5.0.2' to folder"
 * Add a reference to the relevant dll from the above path depending on what .NET Framework you are using. Each folder will cover its version and all future versions. 
 * 
 * Comments: Super easy to use and works well
 * 
 * Tutorial Resource: https://www.emailarchitect.net/easendmail/ex/c/4.aspx
 * 
 */


namespace GmailMessengerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();

            // Your gmail email address
            oMail.From = "DIGNOSTM@gmail.com";

            // Set recipient email address
            oMail.To = "DIGNOSTM@gmail.com";

            // Set email subject
            oMail.Subject = "test email from gmail account";

            // Set email body
            oMail.TextBody = "this is a test email sent from c# project with gmail.";

            // Gmail SMTP server address
            SmtpServer oServer = new SmtpServer("smtp.gmail.com");

            // If you want to use direct SSL 465 port,
            // please add this line, otherwise TLS will be used.
            // oServer.Port = 465;

            // set 587 TLS port;
            oServer.Port = 587;

            // detect SSL/TLS automatically
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

            // Gmail user authentication
            // For example: your email is "gmailid@gmail.com", then the user should be the same
            oServer.User = "DIGNOSTM@gmail.com";
            oServer.Password = "Moore123#";

            try
            {
                Console.WriteLine("start to send email over SSL ...");
                oSmtp.SendMail(oServer, oMail);
                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }

            Console.ReadLine();
        }
    }
}
