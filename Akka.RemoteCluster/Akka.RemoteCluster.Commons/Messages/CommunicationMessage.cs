using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka.RemoteCluster.Commons.Messages
{
    public class CommunicationMessage
    {
        public int MessageId { get; set; }

        public string Message { get; set; }

        public CommunicationMessage(string message)
        {
            this.Message = message;
        }
    }
}
