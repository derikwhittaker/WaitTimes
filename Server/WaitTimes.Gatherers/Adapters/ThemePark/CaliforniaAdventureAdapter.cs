using WaitTimes.Core;
using WaitTimes.Core.Configuration;

namespace WaitTimes.Gatherers.Adapters.ThemePark
{

    public interface ICaliforniaAdventureAdapter : ITimeGathererAdapter
    {

    }

    public class CaliforniaAdventureAdapter : BaseTimeGathererAdapter, ICaliforniaAdventureAdapter
    {
        public CaliforniaAdventureAdapter(ITypedConfiguration typedConfiguration) : base(typedConfiguration)
        {
        }

        public override string Source => "CaliforniaAdventure";
        public override ParkNames ParkId => ParkNames.CaliforniaAdventure;
    }

}