
using System;

namespace WaitTimes.Models.Api
{
    public class CurrentWeatherDto
    {
        
        public string Full { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string StateName { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }

        public DateTime ObservationTime { get; set; }
        public string LocationObservationTime { get; set; }
        public string Weather { get; set; }
        public double TempF { get; set; }
        public double TempC { get; set; }
        public string RelativeHumidity { get; set; }
        public string Wind { get; set; }
        public string WindDirection { get; set; }
        public string HeatIndexF { get; set; }
        public string HeatIndexC { get; set; }
        public string WindchillF { get; set; }
        public string WindchillC { get; set; }
        public string FeelslikeF { get; set; }
        public string FeelslikeC { get; set; }
        
        public string UV { get; set; }
    }
}
