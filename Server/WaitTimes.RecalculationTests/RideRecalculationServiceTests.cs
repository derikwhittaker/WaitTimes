using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using WaitTimes.Models.Dto.Aggregations;
using WaitTimes.Recalculation.Recalculation;
using Xunit;

namespace WaitTimes.RecalculationTests
{
    public class RideRecalculationServiceTests
    {
        [Fact]
        public void SetupEmptyTimeAggregation_Will_Create_Correct_Number_of_Entries()
        {
            var service = new RideRecalculationService(null, null, null);

            var aggregationDto = service.SetupEmptyTimeAggregation();

            aggregationDto.Should().NotBeNull();
            aggregationDto.TimeSlots.Count.Should().Be(96);
        }


        [Fact]
        public void SetupEmptyTimeAggregation_Will_Pull_Correct_Time_For_0_45()
        {
            var service = new RideRecalculationService(null, null, null);

            var aggregationDto = service.SetupEmptyTimeAggregation();

            var timeSlotAggregationDto = aggregationDto.TimeSlots[3];

            timeSlotAggregationDto.Time.Hours.Should().Be(0);
            timeSlotAggregationDto.Time.Minutes.Should().Be(45);
        }

        [Fact]
        public void SetupEmptyTimeAggregation_Will_Pull_Correct_Time_For_12_00()
        {
            var service = new RideRecalculationService(null, null, null);

            var aggregationDto = service.SetupEmptyTimeAggregation();

            var timeSlotAggregationDto = aggregationDto.TimeSlots[48];

            timeSlotAggregationDto.Time.Hours.Should().Be(12);
            timeSlotAggregationDto.Time.Minutes.Should().Be(00);
        }
    }
}
