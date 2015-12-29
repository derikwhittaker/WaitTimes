using System;
using WaitTimes.Models.Dto;
using WaitTimes.Models.Dto.Aggregations;
using WaitTimes.Persistance.Raven;
using WaitTimes.Queue.Messages;
using WaitTimes.Queue.Subscribers;

namespace WaitTimes.Recalculation.Recalculation
{
    public interface IRideRecalculationService
    {
        void Subscribe();
    }

    public class RideRecalculationService : IRideRecalculationService
    {
        private readonly IParkRecalculationSubscriber _parkRecalculationSubscriber;
        private readonly IWaitTimesRepository _waitTimesRepository;
        private readonly IAggregationRepository _aggregationRepository;

        public RideRecalculationService(IParkRecalculationSubscriber parkRecalculationSubscriber, 
            IWaitTimesRepository waitTimesRepository,
            IAggregationRepository aggregationRepository)
        {
            _parkRecalculationSubscriber = parkRecalculationSubscriber;
            _waitTimesRepository = waitTimesRepository;
            _aggregationRepository = aggregationRepository;
        }

        public void Subscribe()
        {
            _parkRecalculationSubscriber.Subscribe(Recalculate);
        }

        public void Recalculate(RecalculationRequestMessage message)
        {
            // fetch core data
            var currentTime = FetchCurrenTime(message.WaitTimeId);

            // fetch aggregation record
            var aggregationDto = FetchAggregation(currentTime);

            Console.WriteLine($"{aggregationDto.RideName} - {message.MessageDateTime} was pulled from queue @ {DateTime.Now}.");

            // fetch data for each recalculation metric

            SaveAggregation(aggregationDto);
        }

        private void SaveAggregation(RideAggregationDto aggregationDto)
        {
            _aggregationRepository.Save(aggregationDto);
        }

        private RideAggregationDto FetchAggregation(CurrentTimeDto currentTime)
        {
            var aggregationDto = _aggregationRepository.Fetch(currentTime.RideName) ?? new RideAggregationDto
            {
                Id = Guid.NewGuid().ToString(),
                RideName = currentTime.RideName,
                ParkName = currentTime.ParkName,
                ParkId = currentTime.ParkId
            };

            return aggregationDto;
        }

        public CurrentTimeDto FetchCurrenTime(string id)
        {
            var currentTimeDto = _waitTimesRepository.Fetch(id);

            return currentTimeDto;
        }
    }
}
