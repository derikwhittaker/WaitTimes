
using System;
using WaitTimes.Models.Api;

namespace WaitTimes.Models.Dto
{
    public class CurrentTimeDto
    {
        public string Id { get; set; }
        public int ParkId { get; set; }
        public string ParkName { get; set; }
        public string RideName { get; set; }
        public bool IsOpened { get; set; }
        public int WaitTime { get; set; }
        public string FastPassTime { get; set; }


        public DateTimeDto DateTime { get; set; }
        public CurrentWeatherDto Weather { get; set; }

    }

    public class DateTimeDto
    {
        
        public DateTimeDto(DateTime utcDateTime, TimeSpan time)
        {
            DateTime = utcDateTime;
            Time = time;
        }

        public DateTime DateTime { get; private set; }
        public TimeSpan Time { get; private set; }

        public int Year => DateTime.Year;
        public int Month => DateTime.Month;
        public int Day => DateTime.Day;
        public int Hour => Time.Hours;
        public int Minute => Time.Minutes;


        public int DayOfWeek => (int)DateTime.DayOfWeek;

        public string DayOfWeekName => DateTime.ToString("dddd");

        public bool IsWeekend => DayOfWeek == 6 || DayOfWeek == 0;
    }
    
}
