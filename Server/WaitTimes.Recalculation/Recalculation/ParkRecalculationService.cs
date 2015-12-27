using WaitTimes.Queue.Messages;
using WaitTimes.Queue.Subscribers;

namespace WaitTimes.Recalculation.Recalculation
{
    public interface IParkRecalculationService
    {
        void Subscribe();
    }

    public class ParkRecalculationService : IParkRecalculationService
    {
        private readonly IParkRecalculationSubscriber _parkRecalculationSubscriber;

        public ParkRecalculationService(IParkRecalculationSubscriber parkRecalculationSubscriber)
        {
            _parkRecalculationSubscriber = parkRecalculationSubscriber;
        }

        public void Subscribe()
        {
            _parkRecalculationSubscriber.Subscribe(Recalculate);
        }

        public void Recalculate(RecalculationRequestMessage message)
        {
            
        }
    }
}
