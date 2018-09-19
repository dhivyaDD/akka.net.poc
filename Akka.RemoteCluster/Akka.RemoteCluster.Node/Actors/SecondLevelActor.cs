using Akka.Actor;
using Akka.RemoteCluster.Commons;
using Akka.RemoteCluster.Commons.Messages;
using Akka.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka.RemoteCluster.Node.Actors
{
    class SecondLevelActor : ReceiveActor
    {
        public SecondLevelActor()
        {
            ConsoleHelper.Write("SecondLevelActor::Received message");

            Receive<SecondMessage>(message => Handler(message));
            ReceiveAny(message => Handler(message));
        }

        private bool Handler(object message)
        {
            return true;
        }

        private bool Handler(SecondMessage message)
        {
            ConsoleHelper.WriteYellow("SecondLevelActor::Received Message. Sender Details - {0}, Address: {1}", Sender.Path.ToString(), Sender.Path.Address);
            ConsoleHelper.WriteYellow("SecondLevelActor::Message: {0}", message.Message);

            try
            {
                var thirdLevelActorProps = Props.Create<ThirdLevelActor>().WithDispatcher("akka.default-dispatcher");
                var actorRef = Context.ActorOf(thirdLevelActorProps, "thirdLevelActor");

                var secondMessage = new ThirdMessage(message.Message + " from " + Sender.Path.Address.Host);
                actorRef.Tell(secondMessage);
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteRed(ex.Message);
                return false;
            }
            return true;
        }
    }
}
