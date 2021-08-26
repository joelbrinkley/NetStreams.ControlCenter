using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetStreams.Commerce.Example.Events
{
    public class OrderFullfilled
    {
        public string FullfillmentId { get; set; }
        public string OrderId { get; set; }
    }
}
