using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WaitTimes.Core.Configuration;
using WaitTimes.Models.Api;

//using WaitTimes.Common.Config;

namespace WaitTimes.Gatherers.Adapters.ThemePark
{
    public interface ITimeGathererAdapter
    {
        List<CurrentTime> CurrentTimes();

        Task<CurrentTimeResult> FetchCurrent();

        string Source { get; }
    }

    public abstract class BaseTimeGathererAdapter : ITimeGathererAdapter
    {
        protected readonly ITypedConfiguration _typedConfiguration;

        protected BaseTimeGathererAdapter(ITypedConfiguration typedConfiguration)
        {
            _typedConfiguration = typedConfiguration;
        }

        public List<CurrentTime> CurrentTimes()
        {

            var endpoint = Endpoint;

            return null;
        }

        public async Task<CurrentTimeResult> FetchCurrent()
        {
            var currentTimes = new List<CurrentTime>();

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var result = await httpClient.GetStringAsync(new Uri(Endpoint));

                    if (result != null)
                    {
                        currentTimes = JsonConvert.DeserializeObject<List<CurrentTime>>(result);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            var currentTime = GetCurrentTime(DateTime.UtcNow);
            
            return new CurrentTimeResult
            {
                CurrentTimes = currentTimes,
                DateTimeResult = new DateTimeResult
                {
                    DateTimeRawUtc = DateTime.UtcNow,
                    Time = currentTime
                },
                Source = Source
            };
        }

        protected TimeSpan GetCurrentTime(DateTime dateTime)
        {
            var hour = dateTime.Hour;
            var minutes = dateTime.Minute;

            // determine 15 min interval
            if (minutes >= 0 && minutes <= 7)
            {
                minutes = 0;
            } else if (minutes >= 8 && minutes <= 22)
            {
                minutes = 15;
            }
            else if (minutes >= 23 && minutes <= 37)
            {
                minutes = 30;
            }
            else if (minutes >= 38 && minutes <= 52)
            {
                minutes = 45;
            }
            else
            {
                minutes = 0;
            }

            return new TimeSpan(hour, minutes, 0);
        }

        public virtual string Endpoint
        {
            get
            {
                var location = _typedConfiguration.EndpointLocations.EndpointLocation(Source);

                return location.Url;
            }
        }

        public abstract string Source { get; }
    }
}
