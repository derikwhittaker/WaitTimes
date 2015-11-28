using System.Collections.Generic;

namespace WaitTimes.Core.Configuration
{
    public class ThemeParkSchedules
    {
        public ThemeParkSchedules()
        {
            Schedules = new List<ThemeParkSchedule>();
        }

        public List<ThemeParkSchedule> Schedules { get; set; }
    }

    public class ThemeParkSchedule
    {
        public string ZipCode { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public string TimeZoneName { get; set; }
    }
}