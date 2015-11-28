using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WaitTimes.Core.Configuration;
using WaitTimes.Models.Api;

namespace WaitTimes.Persistance.Raven
{
    public interface IWeatherRepository 
    {
        Task<CurrentWeatherDto> Current(string zipCode);

        Task Save(CurrentWeatherDto currentWeatherDto);
    }

    public class WeatherRepository : IWeatherRepository
    {
        private readonly ITypedConfiguration _typedConfiguration;

        public WeatherRepository(ITypedConfiguration typedConfiguration)
        {
            _typedConfiguration = typedConfiguration;
        }

        public async Task<CurrentWeatherDto> Current(string zipCode)
        {
            var fullEndpoint = $"http://localhost:8080/databases/CurrentWeather/docs/{zipCode}";
            var requestUri = new Uri(fullEndpoint);

            using (var httpClient = new HttpClient())
            {
                var httpResponseMessage = await httpClient.GetAsync(requestUri, HttpCompletionOption.ResponseContentRead);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var result = await httpResponseMessage.Content.ReadAsStringAsync();
//
                    if (!string.IsNullOrEmpty(result))
                    {
                        var currentWeatherDto = JsonConvert.DeserializeObject<CurrentWeatherDto>(result);

                        return currentWeatherDto;
                    }
                }
                

            }

            return null;

        }

        public async Task Save(CurrentWeatherDto currentWeatherDto)
        {
            currentWeatherDto.ObservationTime = DateTime.UtcNow;

            var zipCode = currentWeatherDto.Zip;
            var fullEndpoint = $"http://localhost:8080/databases/CurrentWeather/docs/{zipCode}";
            var requestUri = new Uri(fullEndpoint);
            
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = requestUri;

                var asJson = JsonConvert.SerializeObject(currentWeatherDto);
                var contentPost = new StringContent(asJson, Encoding.UTF8, "application/json");

                await httpClient.PutAsync(requestUri, contentPost);
            }
            
        }
    }
}
