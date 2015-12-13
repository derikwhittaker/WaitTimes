using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaitTimes.Queue.Messages
{

    public class RecalculationRequestMessage
    {
        public int WaitTimeId { get; set; }

        public DateTime MessageDateTime { get; set; }

    }
}
