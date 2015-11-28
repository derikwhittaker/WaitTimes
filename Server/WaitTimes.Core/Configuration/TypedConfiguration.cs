using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace WaitTimes.Core.Configuration
{
    public interface ITypedConfiguration
    {
        DataConfiguration Data { get; }
        ThemeParkScheduleReader ThemeParkSchedule { get; }
        WeatherMapLocationReader WeatherUrls { get; }
    }

    public class TypedConfiguration : ITypedConfiguration
    {
        private DataConfiguration _data;
        private ThemeParkScheduleReader _themeParkScheduleReader;
        private WeatherMapLocationReader _weatherMapLocationReader;


        public DataConfiguration Data
        {
            get
            {
                if (_data == null)
                {
                    _data = new DataConfiguration();
                }

                return _data;
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

    
    public class DataConfiguration
    {
        
        public string Raven => "";
    }
}
