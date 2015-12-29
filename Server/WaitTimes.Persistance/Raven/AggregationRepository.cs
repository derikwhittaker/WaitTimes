using System;
using System.Linq;
using WaitTimes.Models.Dto.Aggregations;

namespace WaitTimes.Persistance.Raven
{
    public interface IAggregationRepository
    {
        RideAggregationDto Fetch(string rideRame);
        void Save(RideAggregationDto aggregationDto);
    }

    public class AggregationRepository : BaseRepository, IAggregationRepository
    {
        public AggregationRepository() : base("WaitTimes")
        {
        }

        public RideAggregationDto Fetch(string rideRame)
        {
            using (var session = Store.OpenSession())
            {

                var currentTimeDtos = session
                    .Query<RideAggregationDto>()
                    .Where(i => i.RideName == rideRame).ToList();

                if (currentTimeDtos.Any())
                {
                    if (currentTimeDtos.Count > 1)
                    {
                        var currentColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Found more than aggregation for {rideRame}");
                        Console.ForegroundColor = currentColor;
                    }

                    var currentTIme = currentTimeDtos[0];

                    return currentTIme;
                }

                return null;
            }
        }

        public void Save(RideAggregationDto aggregationDto)
        {
            using (var session = Store.OpenSession())
            {
                aggregationDto.LastUpdated = DateTime.UtcNow;

                session.Store(aggregationDto);

                session.SaveChanges();
            }
        }
    }
}