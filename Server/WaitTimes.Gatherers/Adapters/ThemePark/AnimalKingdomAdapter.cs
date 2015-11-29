using WaitTimes.Core.Configuration;

namespace WaitTimes.Gatherers.Adapters.ThemePark
{
    public interface IAnimalKingdomAdapter : ITimeGathererAdapter
    {

    }

    public class AnimalKingdomAdapter : BaseTimeGathererAdapter, IAnimalKingdomAdapter
    {
        public AnimalKingdomAdapter(ITypedConfiguration typedConfiguration) : base(typedConfiguration)
        {
        }
        

        public override string Source => "AnimalKingdom";

    
    }
}