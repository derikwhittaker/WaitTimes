using System.Collections.Generic;

namespace WaitTimes.Core.Configuration
{
    public class WeatherLocations
    {
        public List<WeatherLocation> Locations { get; set; }
    }

    public class WeatherLocation
    {
        public string ZipCode { get; set; }
        public string Url { get; set; }
    }
}