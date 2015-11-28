namespace WaitTimes.Gatherers.Adapters.ThemePark
{

    public interface IHollywoodStudiosAdapter : ITimeGathererAdapter
    {

    }

    public class HollywoodStudiosAdapter : BaseTimeGathererAdapter, IHollywoodStudiosAdapter
    {

        public override string Endpoint => "http://localhost:3000/api/hollywoodStudios";

        public override string Source => "HollywoodStudios";
    }
}