using System;
using Autofac;
using WaitTimes.Core;
using WaitTimes.Core.Configuration;
using WaitTimes.Queue;
using WaitTimes.Queue.Subscribers;
using WaitTimes.Services;
using WaitTimes.Services.Recalculation;

namespace WaitTimes.ConsoleSubscriber
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var container = SetupIoC();

            var subscriber = container.Resolve<IParkRecalculationSubscriber>();
            var recalculationService = container.Resolve<IParkRecalculationService>();

            recalculationService.Subscribe();

            subscriber.Subscribe((message) =>
            {
                Console.WriteLine(message);
            });

            Console.WriteLine("Subscriber -- Any key to exit");
            Console.ReadLine();
        }


        private static IContainer SetupIoC()
        {

            var typedConfiguration = new TypedConfiguration();

            var builder = new ContainerBuilder();
            
            builder.RegisterModule(new CoreIoCModule());
            builder.RegisterModule(new ServicesIoCModule());
            builder.RegisterModule(new QueueIoCModule());


            builder.RegisterInstance(typedConfiguration).As<ITypedConfiguration>().ExternallyOwned();


            //build container
            var container = builder.Build();

            return container;
        }
    }
}
