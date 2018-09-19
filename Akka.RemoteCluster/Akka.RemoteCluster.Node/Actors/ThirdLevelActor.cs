using Akka.Actor;
using Akka.RemoteCluster.Commons;
using Akka.RemoteCluster.Commons.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka.RemoteCluster.Node.Actors
{
    public class ThirdLevelActor : ReceiveActor
    {
        public ThirdLevelActor()
        {
            Receive<ThirdMessage>(message => Handler(message));
            ConsoleHelper.Write("ThirdLevelActor::Received message");
        }

        private bool Handler(ThirdMessage message)
        {
            ConsoleHelper.WriteCyan("ThirdLevelActor::Received Message. Sender Details - {0}, Address: {1}", Sender.Path.ToString(), Sender.Path.Address);
            ConsoleHelper.WriteCyan("ThirdLevelActor::Message: {0}", message.Message);
            return true;
        }
    }
}
