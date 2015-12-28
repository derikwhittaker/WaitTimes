using System;
using Autofac;
using WaitTimes.Core;
using WaitTimes.Core.Configuration;
using WaitTimes.Persistance;
using WaitTimes.Queue;
using WaitTimes.Recalculation;
using WaitTimes.Recalculation.Recalculation;


namespace WaitTimes.ConsoleSubscriber
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var container = SetupIoC();
            
            var recalculationService = container.Resolve<IRideRecalculationService>();

            recalculationService.Subscribe();
            
            Console.WriteLine("Subscriber -- Any key to exit");
            Console.ReadLine();
        }


        private static IContainer SetupIoC()
        {

            var typedConfiguration = new TypedConfiguration();

            var builder = new ContainerBuilder();
            
            builder.RegisterModule(new CoreIoCModule());
            builder.RegisterModule(new RecalculationIoCModule());
            builder.RegisterModule(new PersistanceIoCModule());
            builder.RegisterModule(new QueueIoCModule());


            builder.RegisterInstance(typedConfiguration).As<ITypedConfiguration>().ExternallyOwned();


            //build container
            var container = builder.Build();

            return container;
        }
    }
}
