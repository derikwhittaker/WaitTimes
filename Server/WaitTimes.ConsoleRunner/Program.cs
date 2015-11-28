using System;
using System.IO;
using System.Threading;
using Autofac;
using WaitTimes.Core;
using WaitTimes.Core.Configuration;
using WaitTimes.Gatherers.Adapters.Weather;
using WaitTimes.Persistance;
using WaitTimes.Services;
using WaitTimes.Services.ThemeParks;

namespace WaitTimes.ConsoleRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var currentDir = Directory.GetCurrentDirectory();

            var container = SetupIoC();
            var interval = new TimeSpan(0, 15, 0).TotalMilliseconds; // 15 min

            var autoEvent = new AutoResetEvent(false);
            var gatherCallback = container.Resolve<GatherCallback>(); //new GatherCallback();

            var timer = new Timer(gatherCallback.CheckStatus, autoEvent, 1000, (int)interval);


            Console.WriteLine("Any key to exit");
            Console.ReadLine();


        }

        private static IContainer SetupIoC()
        {

            var typedConfiguration = new TypedConfiguration();

            var builder = new ContainerBuilder();

            builder.RegisterType<GatherCallback>();

            builder.RegisterModule(new DisneyLandIoCModule());
            builder.RegisterModule(new PersistanceIoCModule());
            builder.RegisterModule(new CoreIoCModule());


            builder.RegisterInstance(typedConfiguration).As<ITypedConfiguration>().ExternallyOwned();


            //build container
            var container = builder.Build();

            return container;
        }
    }

    public class GatherCallback
    {
        private readonly IThemeParkOrchestrator _themeParkOrchestrator;
        private readonly IWeatherUnderGroundAdapter _weatherUnderGroundAdapter;

        public GatherCallback(IThemeParkOrchestrator themeParkOrchestrator,
            IWeatherUnderGroundAdapter weatherUnderGroundAdapter)
        {
            _themeParkOrchestrator = themeParkOrchestrator;
            _weatherUnderGroundAdapter = weatherUnderGroundAdapter;
        }

        public void CheckStatus(Object stateInfo)
        {
            _themeParkOrchestrator.Orchestrate();
            // _weatherUnderGroundAdapter.CurrentWeather("27519").Wait();
            //            _disneyLandService.Gather().Wait();
            //            _californiaAdventureService.Gather().Wait();
            //            _magicKingdomService.Gather().Wait();
            //            _epcotService.Gather().Wait();
            //            _animalKingdomService.Gather().Wait();
            //            _hollywoodStudiosService.Gather().Wait();

            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("");
            Console.WriteLine("Will Check for data again in 15 minutes - {0}", DateTime.Now.AddMinutes(15));
            Console.WriteLine("");
            Console.ForegroundColor = currentColor;
        }
    }
}
