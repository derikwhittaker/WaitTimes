using WaitTimes.Core;
using WaitTimes.Core.Configuration;

namespace WaitTimes.Gatherers.Adapters.ThemePark
{

    public interface IWaltDisneyStudiosAdapter : ITimeGathererAdapter
    {

    }

    public class WaltDisneyStudiosAdapter : BaseTimeGathererAdapter, IWaltDisneyStudiosAdapter
    {

        public WaltDisneyStudiosAdapter(ITypedConfiguration typedConfiguration) : base(typedConfiguration)
        {
        }

        public override string Source => "WaltDisney Studios";
        public override ParkNames ParkId => ParkNames.WaltDisneyStudio;
    }
}