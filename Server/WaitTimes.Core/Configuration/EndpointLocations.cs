using System.Collections.Generic;

namespace WaitTimes.Core.Configuration
{
    public class EndpointLocations
    {
        public List<EndpointLocation> Endpoints { get; set; } = new List<EndpointLocation>();
    }

    public class EndpointLocation
    {
        public string Key { get; set; }
        public string Url { get; set; }
    }
}