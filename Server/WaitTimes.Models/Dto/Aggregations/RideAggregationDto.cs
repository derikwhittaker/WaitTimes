using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaitTimes.Models.Dto.Aggregations
{
    public class RideAggregationDto
    {
        public string Id { get; set; }

        public int ParkId { get; set; }
        public string ParkName { get; set; }

        public string RideName { get; set; }

        public DateTime LastUpdated { get; set; }

        public TimeAggregationDto TimeAggregationDto { get; set; } = new TimeAggregationDto();
    }

    public class TimeAggregationDto
    {

        public List<TimeSlotAggregationDto> TimeSlots { get; set; } = new List<TimeSlotAggregationDto>();

    }

    public class TimeSlotAggregationDto
    {

        public TimeSpan Time { get; set; }
        public long TotalWaitTime { get; set; }
        public int TotalIterations { get; set; }
        public double TotalAverageWaitTime { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
