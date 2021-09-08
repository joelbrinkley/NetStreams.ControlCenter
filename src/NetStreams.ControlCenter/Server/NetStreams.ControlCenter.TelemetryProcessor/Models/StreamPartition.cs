using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.TelemetryProcessor.Models
{
    public class StreamPartition
    {
        public int Partition { get; set; }
        public string StreamProcessorId { get; set; }
        public long Lag { get; set; }
        public long Offset { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public string Id { get; set; }
    }
}
