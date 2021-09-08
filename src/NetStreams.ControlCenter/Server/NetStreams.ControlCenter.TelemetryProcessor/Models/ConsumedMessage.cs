using System;

namespace NetStreams.ControlCenter.TelemetryProcessor.Models
{
    public class ConsumedMessage
    {
        public Guid Id { get; set; }
        public string StreamProcessorId { get; set; }
        public string Body { get; set; }
        public string Key { get; set; }
        public bool Completed { get; set; }
        public DateTimeOffset StartedOn { get; set; }
        public DateTimeOffset? CompletedOn { get; set; }
        public double? ProcessingDurationSeconds { get; set; }
    }
}
