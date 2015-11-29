using System.Collections.Generic;
using System.Configuration;

namespace WaitTimes.Core.Configuration
{
    public class ThemeParkSchedules
    {
        public List<ThemeParkSchedule> Schedules { get; set; } = new List<ThemeParkSchedule>();
    }

    public class ThemeParkSchedule
    {
        public string ZipCode { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public string TimeZoneName { get; set; }
    }


}