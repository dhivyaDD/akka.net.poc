using Akka.Actor;
using Akka.RemoteCluster.Commons;
using Akka.RemoteCluster.Commons.Messages;
using Akka.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Akka.RemoteCluster.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(6000);
            Console.Title = "RemoteCluster.Client";
            log4net.Config.XmlConfigurator.Configure();

            ConsoleHelper.Write("ClusterClient::Creating Actor System");
            var actorSystem = ActorSystem.Create(Constants.ActorSystemName);

            ConsoleHelper.Write("ClusterClient::Creating FirstLevelActor");
            var topLevelActorProps = Props.Empty.WithRouter(FromConfig.Instance);
            var topLevelActor = actorSystem.ActorOf(topLevelActorProps, "firstLevelActor");
            Thread.Sleep(1000);

            var messageCount = 1;
            for (int messageIndex = 0; messageIndex < messageCount; messageIndex++)
            {
                var messageId = messageIndex + 1;
                var message = string.Format("Hi Everyone! User {0} says Hello.", messageId);
                ConsoleHelper.WriteCyan("ClusterClient::Sending Message {0}. Content: {1}", messageId, message);

                var communicationMessage = new CommunicationMessage(message);
                topLevelActor.Tell(communicationMessage);
            }

            actorSystem.WhenTerminated.Wait();
        }
    }
}
