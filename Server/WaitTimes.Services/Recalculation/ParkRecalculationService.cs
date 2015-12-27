using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaitTimes.Queue.Messages;
using WaitTimes.Queue.Subscribers;

namespace WaitTimes.Services.Recalculation
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
