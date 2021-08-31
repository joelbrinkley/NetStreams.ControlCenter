using System;
using System.Collections;
using System.Collections.Generic;

namespace NetStreams.ControlCenter.TelemetryProcessor.Models
{
    public class StreamProcessor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Running { get; set; }
        public DateTimeOffset LastStarted { get; set; }

        public ICollection<ConsumedMessage> ConsumedMessages { get; set; } = new List<ConsumedMessage>();
    }
}
