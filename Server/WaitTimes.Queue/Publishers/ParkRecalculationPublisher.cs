using System.Threading.Tasks;
using WaitTimes.Core.Configuration;
using WaitTimes.Queue.Messages;

namespace WaitTimes.Queue.Publishers
{
    public interface IParkRecalculationPublisher
    {
        Task Publish(RecalculationRequestMessage message);
    }

    public class ParkRecalculationPublisher : QueueConnectionBase, IParkRecalculationPublisher
    {
        public ParkRecalculationPublisher(ITypedConfiguration configuration) : base(configuration)
        {
        }

        public async Task Publish(RecalculationRequestMessage message)
        {
            await Bus.PublishAsync(message);
        }
    }   
}
