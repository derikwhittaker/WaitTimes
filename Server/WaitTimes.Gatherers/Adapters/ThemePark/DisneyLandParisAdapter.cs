namespace WaitTimes.Gatherers.Adapters.ThemePark
{

    public interface IDisneyLandParisAdapter : ITimeGathererAdapter
    {

    }

    public class DisneyLandParisAdapter : BaseTimeGathererAdapter, IDisneyLandParisAdapter
    {

        public override string Endpoint => "http://localhost:3000/api/disneyLandParis";

        public override string Source => "DisneyLand Paris";
    }
}