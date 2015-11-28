namespace WaitTimes.Gatherers.Adapters.ThemePark
{
    public interface IDisneyLandAdapter : ITimeGathererAdapter
    {
        
    }

    public class DisneyLandAdapter : BaseTimeGathererAdapter, IDisneyLandAdapter
    {

        public override string Endpoint => "http://localhost:3000/api/disneyLand";

        public override string Source => "DisneyLand";
    }

}