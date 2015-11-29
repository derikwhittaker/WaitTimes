using WaitTimes.Core.Configuration;

namespace WaitTimes.Gatherers.Adapters.ThemePark
{

    public interface IHollywoodStudiosAdapter : ITimeGathererAdapter
    {

    }

    public class HollywoodStudiosAdapter : BaseTimeGathererAdapter, IHollywoodStudiosAdapter
    {

        public HollywoodStudiosAdapter(ITypedConfiguration typedConfiguration) : base(typedConfiguration)
        {
        }

        public override string Source => "HollywoodStudios";
    }
}