using System;
using EasyNetQ;
using Newtonsoft.Json;


namespace WaitTimes.Queue.Messages
{
    [Queue("ParkRecalculationQueue", ExchangeName = "ParkRecalculationQueueExchange")]
    
    public class RecalculationRequestMessage
    {
        public string WaitTimeId { get; set; }

        public DateTime MessageDateTime { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
