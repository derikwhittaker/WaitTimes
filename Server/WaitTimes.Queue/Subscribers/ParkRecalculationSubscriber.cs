using System;
using WaitTimes.Core.Configuration;
using WaitTimes.Queue.Messages;

namespace WaitTimes.Queue.Subscribers
{
    public interface IParkRecalculationSubscriber
    {
        void Subscribe(Action<RecalculationRequestMessage> callback);
    }

    public class ParkRecalculationSubscriber : QueueConnectionBase, IParkRecalculationSubscriber
    {
        public ParkRecalculationSubscriber(ITypedConfiguration configuration) : base(configuration)
        {
        }

        public void Subscribe(Action<RecalculationRequestMessage> callback )
        {
            Bus.Subscribe<RecalculationRequestMessage>("ParkRecalculationQueue", callback.Invoke);
        }
    }
}
