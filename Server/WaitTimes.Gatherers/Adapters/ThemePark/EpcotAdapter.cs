namespace WaitTimes.Gatherers.Adapters.ThemePark
{

    public interface IEpcotAdapter : ITimeGathererAdapter
    {

    }

    public class EpcotAdapter : BaseTimeGathererAdapter, IEpcotAdapter
    {

        public override string Endpoint => "http://localhost:3000/api/epcot";

        public override string Source => "Epcot";
    }
}