using WaitTimes.Core.Configuration;
using WaitTimes.Gatherers.Adapters.ThemePark;

namespace WaitTimes.Gatherers.Adapters
{
    public interface IMagicKingdomAdapter : ITimeGathererAdapter
    {

    }

    public class MagicKingdomAdapter : BaseTimeGathererAdapter, IMagicKingdomAdapter
    {

        public MagicKingdomAdapter(ITypedConfiguration typedConfiguration) : base(typedConfiguration)
        {
        }

        public override string Source => "MagicKingdom";
    }
}