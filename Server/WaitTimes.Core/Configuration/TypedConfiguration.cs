using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace WaitTimes.Core.Configuration
{
    public interface ITypedConfiguration
    {
        EndpointLocationReader EndpointLocations { get; }
        ThemeParkScheduleReader ThemeParkSchedule { get; }
        WeatherMapLocationReader WeatherUrls { get; }
    }

    public class TypedConfiguration : ITypedConfiguration
    {
        private EndpointLocationReader _endpointLocationReader;
        private ThemeParkScheduleReader _themeParkScheduleReader;
        private WeatherMapLocationReader _weatherMapLocationReader;

        public EndpointLocationReader EndpointLocations
        {
            get
            {
                if (_endpointLocationReader == null)
                {
                    _endpointLocationReader = new EndpointLocationReader();
                }

                return _endpointLocationReader;
            }
        }

        public ThemeParkScheduleReader ThemeParkSchedule
        {
            get
            {
                if (_themeParkScheduleReader == null)
                {
                    _themeParkScheduleReader = new ThemeParkScheduleReader();
                }

                return _themeParkScheduleReader;
            }
        }

        public WeatherMapLocationReader WeatherUrls
        {
            get
            {
                if (_weatherMapLocationReader == null)
                {
                    _weatherMapLocationReader = new WeatherMapLocationReader();
                }

                return _weatherMapLocationReader;
            }
        }
    }

    public class WeatherMapLocationReader
    {
        private string ConfigFileFullPath;  
        private readonly WeatherLocations WeatherLocations;

        public WeatherMapLocationReader()
        {
            var fileName = ConfigurationManager.AppSettings["WatherLocationMap"];
            var currentDirectory = Directory.GetCurrentDirectory();

            ConfigFileFullPath = Path.Combine(currentDirectory, fileName);

            if (File.Exists(ConfigFileFullPath))
            {
                using (var sr = new StreamReader(ConfigFileFullPath))
                {
                    var rawJson = sr.ReadToEnd();

                    Debug.WriteLine(rawJson);

                    WeatherLocations = JsonConvert.DeserializeObject<WeatherLocations>(rawJson);
                }
            }

        }

        public WeatherLocation WeatherLocation(string zipCode)
        {
            var foundLocation = WeatherLocations.Locations.FirstOrDefault(x => x.ZipCode == zipCode);

            return foundLocation;
        }
        
    }

    public class ThemeParkScheduleReader
    {
        private string ConfigFileFullPath;
        private readonly ThemeParkSchedules ThemeParkSchedules;

        public ThemeParkScheduleReader()
        {
            var fileName = ConfigurationManager.AppSettings["ThemeParkScheduleJson"];
            var currentDirectory = Directory.GetCurrentDirectory();

            ConfigFileFullPath = Path.Combine(currentDirectory, fileName);

            if (File.Exists(ConfigFileFullPath))
            {
                using (var sr = new StreamReader(ConfigFileFullPath))
                {
                    var rawJson = sr.ReadToEnd();

                    Debug.WriteLine(rawJson);

                    ThemeParkSchedules = JsonConvert.DeserializeObject<ThemeParkSchedules>(rawJson);
                }
            }

        }

        public ThemeParkSchedule ThemeParkSchedule(string zipCode)
        {
            var foundSchedule = ThemeParkSchedules.Schedules.FirstOrDefault(x => x.ZipCode == zipCode);

            return foundSchedule;
        }        
    }

    public class EndpointLocationReader
    {
        private readonly EndpointLocations _endpointLocations;

        public EndpointLocationReader()
        {
            var fileName = ConfigurationManager.AppSettings["EndpointLocationsJson"];
            var currentDirectory = Directory.GetCurrentDirectory();

            var configFileFullPath = Path.Combine(currentDirectory, fileName);

            if (File.Exists(configFileFullPath))
            {
                using (var sr = new StreamReader(configFileFullPath))
                {
                    var rawJson = sr.ReadToEnd();
                    
                    _endpointLocations = JsonConvert.DeserializeObject<EndpointLocations>(rawJson);
                }
            }

        }

        public EndpointLocation EndpointLocation(string key)
        {
            var foundSchedule = _endpointLocations.Endpoints.FirstOrDefault(x => x.Key == key);

            return foundSchedule;
        }
    }


    public class DataConfiguration
    {
        
        public string Raven => "";
    }
}
