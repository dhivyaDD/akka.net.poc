using Akka.Actor;
using Akka.RemoteCluster.Commons;
using Akka.RemoteCluster.Node.Actors;
using Akka.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Akka.RemoteCluster.Node
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(1000);
            Console.Title = "RemoteCluster.Node";
            log4net.Config.XmlConfigurator.Configure();

            ConsoleHelper.Write("ClusterClient::Creating Actor System");
            var actorSystem = ActorSystem.Create(Constants.ActorSystemName);

            var props1 = Props.Create<FirstLevelActor>().WithRouter(FromConfig.Instance);
            var firstLevelActor = actorSystem.ActorOf(props1, "firstLevelActor");

            //var props2 = Props.Create<SecondLevelActor>().WithRouter(FromConfig.Instance);
            //var secondLevelActor = actorSystem.ActorOf(props2, "secondLevelActor");

            //var routees = firstLevelActor.Ask<Routees>(new GetRoutees()).Result.Members;

            actorSystem.WhenTerminated.Wait();
        }
    }
}
