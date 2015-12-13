using System;
using System.Threading.Tasks;
using WaitTimes.Core.Configuration;
using WaitTimes.Queue.Messages;

namespace WaitTimes.Queue.Publishers
{
    public interface IParkRecalculationPublisher
    {
        //Task Publish(RecalculationRequestMessage message);
        void Publish(RecalculationRequestMessage message);
    }

    public class ParkRecalculationPublisher : QueueConnectionBase, IParkRecalculationPublisher
    {
        public ParkRecalculationPublisher(ITypedConfiguration configuration) : base(configuration)
        {
        }

        public void Publish(RecalculationRequestMessage message)
        {
            //await Bus.PublishAsync(message);
            try
            {
                Bus.Publish(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }   
}
