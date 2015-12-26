using System;
using WaitTimes.Core.Configuration;
using WaitTimes.Queue.Messages;

namespace WaitTimes.Queue.Subscribers
{
    public interface IParkRecalculationSubscriber
    {
        void Subscribe();
    }

    public class ParkRecalculationSubscriber : QueueConnectionBase, IParkRecalculationSubscriber
    {
        public ParkRecalculationSubscriber(ITypedConfiguration configuration) : base(configuration)
        {
        }

        public void Subscribe()
        {
            Bus.Subscribe<RecalculationRequestMessage>("ParkRecalculationQueue",
                message =>
                {
                    Console.WriteLine(message);
                });
        }
    }
}
