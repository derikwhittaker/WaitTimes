using Newtonsoft.Json;

namespace WaitTimes.Models.Api
{
    public class WeatherResult
    {

        [JsonProperty(PropertyName = "current_observation")]
        public CurrentObservation CurrentObservation { get; set; }
    }


    public class CurrentObservation
    {
        [JsonProperty(PropertyName = "display_location")]
        public DisplayLocation DisplayLocation { get; set; }

        [JsonProperty(PropertyName = "observation_time")]
        public string ObservationTime { get; set; }

        [JsonProperty(PropertyName = "weather")]
        public string Weather { get; set; }

        [JsonProperty(PropertyName = "temp_f")]
        public double TempF { get; set; }

        [JsonProperty(PropertyName = "temp_c")]
        public double TempC { get; set; }

        [JsonProperty(PropertyName = "relative_humidity")]
        public string RelativeHumidity { get; set; }

        [JsonProperty(PropertyName = "wind_string")]
        public string Wind { get; set; }

        [JsonProperty(PropertyName = "wind_dir")]
        public string WindDirection { get; set; }

        [JsonProperty(PropertyName = "heat_index_f")]
        public string HeatIndexF { get; set; }

        [JsonProperty(PropertyName = "heat_index_c")]
        public string HeatIndexC { get; set; }

        [JsonProperty(PropertyName = "windchill_f")]
        public string WindchillF { get; set; }

        [JsonProperty(PropertyName = "windchill_c")]
        public string WindchillC { get; set; }

        [JsonProperty(PropertyName = "feelslike_f")]
        public string FeelslikeF { get; set; }

        [JsonProperty(PropertyName = "feelslike_c")]
        public string FeelslikeC { get; set; }

        [JsonProperty(PropertyName = "uv")]
        public string UV { get; set; }
    }
}