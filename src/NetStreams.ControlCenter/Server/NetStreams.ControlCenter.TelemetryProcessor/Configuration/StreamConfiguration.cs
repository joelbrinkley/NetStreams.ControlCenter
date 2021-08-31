using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.TelemetryProcessor.Configuration
{
    public class StreamConfiguration
    {
        public string BootstrapServers { get; set; }
        public string ConsumerGroup { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public string AutoOffsetReset { get; set; } = "Latest";
    }
}
