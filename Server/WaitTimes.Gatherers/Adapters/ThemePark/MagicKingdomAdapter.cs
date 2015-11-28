using WaitTimes.Gatherers.Adapters.ThemePark;

namespace WaitTimes.Gatherers.Adapters
{
    public interface IMagicKingdomAdapter : ITimeGathererAdapter
    {

    }

    public class MagicKingdomAdapter : BaseTimeGathererAdapter, IMagicKingdomAdapter
    {

        public override string Endpoint => "http://localhost:3000/api/magicKingdom";

        public override string Source => "MagicKingdom";
    }
}