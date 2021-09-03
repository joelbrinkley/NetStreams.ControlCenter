using System;

namespace NetStreams.ControlCenter.TelemetryProcessor.Models
{
    public class ConsumedMessage
    {
        public Guid Id { get; set; }
        public string StreamProcessorId { get; set; }
        public string Body { get; set; }
        public string Key { get; set; }
    }
}
