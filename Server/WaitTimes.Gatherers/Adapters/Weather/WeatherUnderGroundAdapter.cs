
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WaitTimes.Models.Api;

namespace WaitTimes.Gatherers.Adapters.Weather
{
    public interface IWeatherUnderGroundAdapter
    {
        Task<WeatherResult> CurrentWeather(string zipCodeMap);
    }

    public class WeatherUnderGroundAdapter : IWeatherUnderGroundAdapter
    {
        public async Task<WeatherResult> CurrentWeather(string zipCodeMap)
        {
            WeatherResult weatherResult = null;
            var fullEndpoint = string.Format(Endpoint, Key, zipCodeMap);

            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetStringAsync(new Uri(fullEndpoint));

                if (result != null)
                {
                    weatherResult = JsonConvert.DeserializeObject<WeatherResult>(result);
                }
            }

            return weatherResult;
        }

        private string Key => "7fb9d4857d22334a";

        private string Endpoint => "http://api.wunderground.com/api/{0}/conditions/q/{1}";
    }
}
