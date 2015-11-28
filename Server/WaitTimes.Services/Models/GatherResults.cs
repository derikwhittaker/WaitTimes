using System.Collections.Generic;
using WaitTimes.Models.Dto;

namespace WaitTimes.Services.Models
{
    public class GatherResults
    {
        
        public List<CurrentTimeDto> CurrentTimes { get; set; } = new List<CurrentTimeDto>();
        public string ZipCode { get; set; }
        public string Source { get; set; }
    }
}
