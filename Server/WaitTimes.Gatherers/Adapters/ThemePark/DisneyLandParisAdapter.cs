using WaitTimes.Core;
using WaitTimes.Core.Configuration;

namespace WaitTimes.Gatherers.Adapters.ThemePark
{

    public interface IDisneyLandParisAdapter : ITimeGathererAdapter
    {

    }

    public class DisneyLandParisAdapter : BaseTimeGathererAdapter, IDisneyLandParisAdapter
    {

        public DisneyLandParisAdapter(ITypedConfiguration typedConfiguration) : base(typedConfiguration)
        {
        }

        public override string Source => "DisneyLand Paris";
        public override ParkNames ParkId => ParkNames.DisneyLandParis;
    }
}