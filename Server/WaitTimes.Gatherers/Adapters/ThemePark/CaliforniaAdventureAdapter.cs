namespace WaitTimes.Gatherers.Adapters.ThemePark
{

    public interface ICaliforniaAdventureAdapter : ITimeGathererAdapter
    {

    }

    public class CaliforniaAdventureAdapter : BaseTimeGathererAdapter, ICaliforniaAdventureAdapter
    {

        public override string Endpoint => "http://localhost:3000/api/californiaAdventure";

        public override string Source => "CaliforniaAdventure";
    }

}