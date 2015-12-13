using System;
using System.Dynamic;
using System.Runtime;
using EasyNetQ;
using EasyNetQ.Events;
using WaitTimes.Core.Configuration;

namespace WaitTimes.Queue
{
    public class QueueConnectionBase
    {
        private readonly ITypedConfiguration _configuration;
        private IBus _bus;

        public QueueConnectionBase( ITypedConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IBus Bus
        {
            get
            {
                if (_bus == null)
                {
                    _bus = RabbitHutch.CreateBus(QueueConnectionString);
                }

                return _bus;                
            }
        }

        public string QueueConnectionString => _configuration.EndpointLocations.EndpointLocation("RabbitMQ").Url;
    }
}
