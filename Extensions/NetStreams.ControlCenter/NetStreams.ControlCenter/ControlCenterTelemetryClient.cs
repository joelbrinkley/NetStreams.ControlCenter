using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using NetStreams.Telemetry;

namespace NetStreams.ControlCenter
{
    public class ControlCenterTelemetryClient : INetStreamTelemetryClient
    {
        private NetStreamProducer<string, NetStreamsTelemetryEvent> _producer { get; }

        public ControlCenterTelemetryClient(NetStreamProducer<string, NetStreamsTelemetryEvent> producer)
        {
            _producer = producer;
        }

        public async Task SendAsync(NetStreamsTelemetryEvent telemetryEvent, CancellationToken token)
        {
            await _producer.ProduceAsync(telemetryEvent.StreamProcessorName, telemetryEvent);
        }
    }
}
