using System;
using System.Threading.Tasks;
using WaitTimes.Core.Configuration;
using WaitTimes.Gatherers.Adapters.Weather;
using WaitTimes.Models.Api;
using WaitTimes.Persistance.Raven;

namespace WaitTimes.Services.Weather
{
    public interface IWeatherService
    {
        Task<CurrentWeatherDto> Current(string zipCode);
    }

    public class WeatherService : IWeatherService
    {
        private const int WeatherIntervalLimit = 60;
        private readonly IWeatherUnderGroundAdapter _weatherUnderGroundAdapter;
        private readonly IWeatherRepository _weatherRepository;
        private readonly ITypedConfiguration _typedConfiguration;

        public WeatherService(IWeatherUnderGroundAdapter weatherUnderGroundAdapter, IWeatherRepository weatherRepository, ITypedConfiguration typedConfiguration)
        {
            _weatherUnderGroundAdapter = weatherUnderGroundAdapter;
            _weatherRepository = weatherRepository;
            _typedConfiguration = typedConfiguration;
        }

        public async Task<CurrentWeatherDto> Current(string zipCode)
        {
            var currentWeather = await GetCurrentWeatherInformation(zipCode);
            
            return currentWeather;
        }

        private async Task<CurrentWeatherDto> GetCurrentWeatherInformation(string zipCode)
        {
            var currentWeatherDto = await _weatherRepository.Current(zipCode);

            if (currentWeatherDto == null || IsWeatherStale(currentWeatherDto))
            {
                var zipCodeMap = _typedConfiguration.WeatherUrls.WeatherLocation(zipCode);
                var currentWeatherResult = await _weatherUnderGroundAdapter.CurrentWeather(zipCodeMap.Url);
                currentWeatherDto = MapToDto(currentWeatherResult, zipCode);

                await _weatherRepository.Save(currentWeatherDto);          
                
                Console.WriteLine($"Fetched updated weather for {zipCode} at {DateTime.UtcNow}");
            }

            return currentWeatherDto;
        }

        private bool IsWeatherStale(CurrentWeatherDto currentWeatherDto)
        {
            if( currentWeatherDto == null) { return true; }

            var utcNow = DateTime.UtcNow;
            var lastCheckTime = currentWeatherDto.ObservationTime;

            var timeSpan = utcNow.Subtract(lastCheckTime);

            return (timeSpan.TotalMinutes > WeatherIntervalLimit);
        }

        private CurrentWeatherDto MapToDto(WeatherResult currentWeatherResult, string zipCode)
        {
            if (currentWeatherResult == null) { return new CurrentWeatherDto();}

            var currentObservation = currentWeatherResult.CurrentObservation;
            var displayLocation = currentObservation.DisplayLocation;
            return new CurrentWeatherDto
            {
                Full = displayLocation.Full,
                City = displayLocation.City,
                State = displayLocation.State,
                StateName = displayLocation.StateName,
                Country = displayLocation.Country,
                Zip = zipCode, // international does not return zip code
                LocationObservationTime = currentObservation.ObservationTime,
                Weather = currentObservation.Weather,
                TempC = currentObservation.TempC,
                TempF = currentObservation.TempF,
                RelativeHumidity = currentObservation.RelativeHumidity,
                Wind = currentObservation.Wind,
                WindDirection = currentObservation.WindDirection,
                HeatIndexF = currentObservation.HeatIndexF,
                HeatIndexC = currentObservation.HeatIndexC,
                WindchillF = currentObservation.WindchillF,
                WindchillC = currentObservation.WindchillC,
                FeelslikeF = currentObservation.FeelslikeF,
                FeelslikeC = currentObservation.FeelslikeC,
                UV = currentObservation.UV,
            };
        }
    }
}
