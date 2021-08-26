using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetStreams.Commerce.Example.Events
{
    public class OrderSubmitted
    {
        public string OrderId { get; set; }
        public IEnumerable<string> Order { get; set; }
    }
}
