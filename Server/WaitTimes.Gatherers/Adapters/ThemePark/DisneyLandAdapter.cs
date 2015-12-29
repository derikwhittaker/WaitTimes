using WaitTimes.Core;
using WaitTimes.Core.Configuration;

namespace WaitTimes.Gatherers.Adapters.ThemePark
{
    public interface IDisneyLandAdapter : ITimeGathererAdapter
    {
        
    }

    public class DisneyLandAdapter : BaseTimeGathererAdapter, IDisneyLandAdapter
    {

        public DisneyLandAdapter(ITypedConfiguration typedConfiguration) : base(typedConfiguration)
        {
        }

        public override string Source => "DisneyLand";
        public override ParkNames ParkId => ParkNames.DisneyLand;
    }

}