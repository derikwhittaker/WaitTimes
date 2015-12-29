using WaitTimes.Core;
using WaitTimes.Core.Configuration;

namespace WaitTimes.Gatherers.Adapters.ThemePark
{

    public interface IEpcotAdapter : ITimeGathererAdapter
    {

    }

    public class EpcotAdapter : BaseTimeGathererAdapter, IEpcotAdapter
    {

        public EpcotAdapter(ITypedConfiguration typedConfiguration) : base(typedConfiguration)
        {
        }

        public override string Source => "Epcot";
        public override ParkNames ParkId => ParkNames.Epcot;
    }
}