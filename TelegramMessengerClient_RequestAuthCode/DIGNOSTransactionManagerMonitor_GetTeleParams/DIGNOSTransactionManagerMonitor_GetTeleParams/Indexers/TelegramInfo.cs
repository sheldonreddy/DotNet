using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Telegram
using TeleSharp.TL;
using TeleSharp.TL.Messages;
using TLSharp.Core;
using TLSharp.Core.Network;
using TLSharp.Core.Requests;
using TLSharp.Core.Utils;

namespace DIGNOSTransactionManagerMonitor_GetTeleParams.Indexers
{

    /// <summary>
    ///     TELEGRAMINFO is an Indexer which holds the information required
    ///     by the Telegram Messaging API to perform the relevant functions.
    /// </summary>
    public class TelegramInfo
    {

        public TelegramClient Client { get; set; }

        public int ApiId { get; set; } = 0;

        public string ApiHash { get; set; } = "";

        public string AuthHash { get; set; }

        public string AuthCode { get; set; } = "";

        public string SourceNumber { get; set; } = "";

        public string DestinationNumber { get; set; } = "";

        public string ChannelName { get; set; }


    }
}
