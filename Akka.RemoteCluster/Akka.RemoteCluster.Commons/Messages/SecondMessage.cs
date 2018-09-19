using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka.RemoteCluster.Commons.Messages
{
    public class SecondMessage
    {
        public string Message { get; set; }

        public SecondMessage(string message)
        {
            this.Message = message;
        }
    }
}
