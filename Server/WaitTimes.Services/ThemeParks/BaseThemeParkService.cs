using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WaitTimes.Core.Configuration;
using WaitTimes.Core.Extensions;
using WaitTimes.Gatherers.Adapters.ThemePark;
using WaitTimes.Models.Api;
using WaitTimes.Models.Dto;
using WaitTimes.Services.Models;

namespace WaitTimes.Services.ThemeParks
{
    public abstract class BaseThemeParkService
    {
        private readonly ITimeGathererAdapter _serviceAdapter;
        private readonly ITypedConfiguration _typedConfiguration;

        protected BaseThemeParkService(ITimeGathererAdapter serviceAdapter, ITypedConfiguration typedConfiguration)
        {
            _serviceAdapter = serviceAdapter;
            _typedConfiguration = typedConfiguration;
        }

        public async Task<GatherResults> Gather(CurrentWeatherDto weatherResult)
        {
            if (!CanGatherData(this.LocationZipCode)) { return new GatherResults {ZipCode = LocationZipCode, Source = _serviceAdapter.Source}; }

            // fetch new current time from remote host
            var remoteHostCurrentTimes = await FetchCurrentTimes();

            var currentTimeDtos = TransformResults(remoteHostCurrentTimes, weatherResult);
            
            return new GatherResults
            {
                Source = _serviceAdapter.Source,
                ZipCode = this.LocationZipCode,
                CurrentTimes = currentTimeDtos
            };
        }

        private async Task<CurrentTimeResult> FetchCurrentTimes()
        {
            var remoteHostCurrentTimes = await _serviceAdapter.FetchCurrent();

            foreach (var currentTime in remoteHostCurrentTimes.CurrentTimes)
            {
                currentTime.Name = ScrubName(currentTime.Name);
            }

            return remoteHostCurrentTimes;
        }

        private string ScrubName(string name)
        {
         
            name = name.Replace("\"", "")
                .Replace("«", "")
                .Replace("»", "")
                .Trim();
            
            return name;
        }


        protected List<CurrentTimeDto> TransformResults(CurrentTimeResult remoteHostCurrentTimes, CurrentWeatherDto weatherResult)
        {
            var results = new List<CurrentTimeDto>();
            var dateTimeRawUtc = remoteHostCurrentTimes.DateTimeResult.DateTimeRawUtc;
            var time = remoteHostCurrentTimes.DateTimeResult.Time;

            foreach (var currentTime in remoteHostCurrentTimes.CurrentTimes)
            {
                var currentTimeDto = new CurrentTimeDto
                {
                    RideName = currentTime.Name,
                    IsOpened = currentTime.WaitTime.IsOpened(),
                    WaitTime = currentTime.WaitTime.TimeInMinutes(),
                    FastPassTime = currentTime.FastPass,
                    DateTime = new DateTimeDto(dateTimeRawUtc, time),
                    Weather = weatherResult,
                    ParkId = remoteHostCurrentTimes.ParkId,
                    ParkName = remoteHostCurrentTimes.ParkName

                };

                results.Add(currentTimeDto);
            }

            return results;
        }

        protected bool CanGatherData(string zipCode)
        {
            var themeParkSchedule = _typedConfiguration.ThemeParkSchedule.ThemeParkSchedule(zipCode);
            if (themeParkSchedule == null) { return true; }

            var utcNow = DateTime.Now;
            var start = new DateTime(utcNow.Year, utcNow.Month, utcNow.Day, themeParkSchedule.Start, 0, 0);
            var end = new DateTime(utcNow.Year, utcNow.Month, utcNow.Day, themeParkSchedule.End, 0, 0);

            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(themeParkSchedule.TimeZoneName);
            var convertedTimeZone = TimeZoneInfo.ConvertTime(DateTime.Now, timeZone);

            return (convertedTimeZone >= start && convertedTimeZone <= end);
        }

        public abstract string LocationZipCode { get; }
    }
}