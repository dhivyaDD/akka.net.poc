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
    public class FirstLevelActor : ReceiveActor
    {
        public FirstLevelActor()
        {
            ConsoleHelper.Write("TopLevelActor::Received message");
            Receive<CommunicationMessage>(message => Handler(message));
        }

        private bool Handler(CommunicationMessage message)
        {
            ConsoleHelper.WriteGreen("TopLevelActor::Received Message. Sender Details - {0}, Address: {1}", Sender.Path, Sender.Path.Address);
            ConsoleHelper.WriteGreen("TopLevelActor::Message: {0}", message.Message);

            try
            {
                //var secondLevelActorProps = Props.Create<SecondLevelActor>().WithRouter(FromConfig.Instance);

                var secondLevelActorProps = Props.Create<SecondLevelActor>().WithDispatcher("akka.default-dispatcher");
                var secondLevelActor = Context.ActorOf(secondLevelActorProps, "secondLevelActor");

                var secondMessage = new SecondMessage(message.Message + " from " + Sender.Path.Address.Host);
                secondLevelActor.Tell(secondMessage);
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
