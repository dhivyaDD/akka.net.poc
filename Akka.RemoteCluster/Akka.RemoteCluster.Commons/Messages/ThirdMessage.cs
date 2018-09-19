using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka.RemoteCluster.Commons.Messages
{
    public class ThirdMessage
    {
        public string Message { get; set; }

        public ThirdMessage(string message)
        {
            this.Message = message;
        }
    }
}
