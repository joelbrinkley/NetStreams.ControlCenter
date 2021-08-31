using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.TelemetryProcessor.Models
{
    public class ConsumedMessage
    {
        public Guid StreamProcessorId { get; set; }
        public string Body { get; set; }
        public string Key { get; set; }
    }
}
