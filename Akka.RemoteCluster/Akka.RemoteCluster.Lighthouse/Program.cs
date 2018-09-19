using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Akka.RemoteCluster.Lighthouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "AkkaCluster.Lighthouse";
            log4net.Config.XmlConfigurator.Configure();
            HostFactory.Run(x =>
            {
                x.SetServiceName("Akka.Lighthouse");
                x.SetDisplayName("Lighthouse Service for Akka Cluster");
                x.SetDescription("Lighthouse (Seed node) service for Akka.Samples.Cluster");

                x.UseAssemblyInfoForServiceInfo();
                x.RunAsLocalSystem();
                x.StartAutomatically();

                x.Service<LighthouseService>(sc =>
                {
                    sc.ConstructUsing(() => new LighthouseService());

                    // the start and stop methods for the service
                    sc.WhenStarted(s => s.Start());
                    sc.WhenStopped(s => s.StopAsync().Wait());
                });

                x.EnableServiceRecovery(r => r.RestartService(1));
            });
        }
    }
}
