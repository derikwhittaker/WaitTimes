namespace WaitTimes.Gatherers.Adapters.ThemePark
{
    public interface IAnimalKingdomAdapter : ITimeGathererAdapter
    {

    }

    public class AnimalKingdomAdapter : BaseTimeGathererAdapter, IAnimalKingdomAdapter
    {

        public override string Endpoint => "http://localhost:3000/api/animalKingdom";

        public override string Source => "AnimalKingdom";
    }
}