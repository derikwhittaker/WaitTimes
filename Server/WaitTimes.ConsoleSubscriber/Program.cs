using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using WaitTimes.Core;
using WaitTimes.Core.Configuration;
using WaitTimes.Queue;
using WaitTimes.Queue.Subscribers;

namespace WaitTimes.ConsoleSubscriber
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var container = SetupIoC();

            var subscriber = container.Resolve<IParkRecalculationSubscriber>();

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
            builder.RegisterModule(new QueueIoCModule());


            builder.RegisterInstance(typedConfiguration).As<ITypedConfiguration>().ExternallyOwned();


            //build container
            var container = builder.Build();

            return container;
        }
    }
}
