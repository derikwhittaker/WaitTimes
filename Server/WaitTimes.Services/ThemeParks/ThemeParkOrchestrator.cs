using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WaitTimes.Persistance.Raven;
using WaitTimes.Queue.Messages;
using WaitTimes.Queue.Publishers;
using WaitTimes.Services.Weather;

namespace WaitTimes.Services.ThemeParks
{
    public interface IThemeParkOrchestrator
    {
        Task Orchestrate();
    }

    public class ThemeParkOrchestrator : IThemeParkOrchestrator
    {
        private readonly IWeatherService _weatherService;
        private readonly IWaitTimesRepository _persister;
        private readonly IParkRecalculationPublisher _parkRecalculationPublisher;
        private IList<IThemeParkService> _themeParkServices = new List<IThemeParkService>();

        public ThemeParkOrchestrator(IWeatherService weatherService,
            IWaitTimesRepository persister,
            IParkRecalculationPublisher parkRecalculationPublisher,
            IAnimalKingdomService animalKingdomService,
            ICaliforniaAdventureService californiaAdventureService,
            IDisneyLandService disneyLandService,
            IDisneyLandParisService disneyLandParisService,
            IEpcotService epcotService,
            IHollywoodStudiosService hollywoodStudiosService,
            IMagicKingdomService magicKingdomService,
            IWaltDisneyStudiosService waltDisneyStudiosService)
        {
            _weatherService = weatherService;
            _persister = persister;
            _parkRecalculationPublisher = parkRecalculationPublisher;
            _themeParkServices.Add(animalKingdomService);
            _themeParkServices.Add(californiaAdventureService);
            _themeParkServices.Add(disneyLandService);
            _themeParkServices.Add(disneyLandParisService);
            _themeParkServices.Add(epcotService);
            _themeParkServices.Add(hollywoodStudiosService);
            _themeParkServices.Add(magicKingdomService);
            _themeParkServices.Add(waltDisneyStudiosService);
        }

        public async Task Orchestrate()
        {
            foreach (var themeParkService in _themeParkServices)
            {
                try
                {
                    var locationZipCode = themeParkService.LocationZipCode;
                    var weatherResult = await _weatherService.Current(locationZipCode);

                    var results = await themeParkService.Gather(weatherResult);

                    Console.WriteLine($"Writing {results.CurrentTimes.Count} records for Souce {results.Source} and Zip Code {results.ZipCode}");

                    var resultDtos = _persister.Save(results.CurrentTimes);

                    // publish in order to update stats
                    resultDtos.ForEach( d => _parkRecalculationPublisher.Publish(new RecalculationRequestMessage
                    {
                        WaitTimeId = d.Id,
                        MessageDateTime = d.DateTime.DateTime
                    }));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}