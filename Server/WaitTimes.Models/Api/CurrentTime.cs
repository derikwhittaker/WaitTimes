using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WaitTimes.Models.Api
{
    public class CurrentTime
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "waitTime")]
        public string WaitTime { get; set; }

        [JsonProperty(PropertyName = "fastPass")]
        public string FastPass { get; set; }

        [JsonProperty(PropertyName = "active")]
        public string Active { get; set; }
    }

    public class CurrentTimeResult
    {
        public string Version => "2.0";

        public List<CurrentTime> CurrentTimes { get; set; }

        public DateTimeResult DateTimeResult { get; set; }

        public WeatherResult WeatherResults { get; set; }

        public string ParkName { get; set; }
        public int ParkId { get; set; }
    }

    public class DateTimeResult
    {
        public DateTime DateTimeRawUtc { get; set; }

        public TimeSpan Time { get; set; }

     

// (6 == sat 0 == sun)
    }


    public class DisplayLocation
    {
        [JsonProperty(PropertyName = "full")]
        public string Full { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "state_name")]
        public string StateName { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        
        [JsonProperty(PropertyName = "zip")]
        public string Zip { get; set; }
    }

}
