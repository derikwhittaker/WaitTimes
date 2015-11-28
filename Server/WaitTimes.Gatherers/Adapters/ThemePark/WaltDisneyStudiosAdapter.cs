namespace WaitTimes.Gatherers.Adapters.ThemePark
{

    public interface IWaltDisneyStudiosAdapter : ITimeGathererAdapter
    {

    }

    public class WaltDisneyStudiosAdapter : BaseTimeGathererAdapter, IWaltDisneyStudiosAdapter
    {

        public override string Endpoint => "http://localhost:3000/api/waltDisneyStudios";

        public override string Source => "WaltDisney Studios";
    }
}