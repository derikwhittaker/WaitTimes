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
                    .FirstOrDefault(i => i.RideName == rideRame);

                return currentTimeDtos;
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