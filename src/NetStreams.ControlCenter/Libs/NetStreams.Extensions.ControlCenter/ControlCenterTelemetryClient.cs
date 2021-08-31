using Confluent.Kafka;
using NetStreams.Telemetry;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetStreams.Extensions.ControlCenter
{
    public class ControlCenterTelemetryClient : INetStreamTelemetryClient
    {
        private NetStreamProducer<string, NetStreamTelemetryEvent> _producer { get; }

        public ControlCenterTelemetryClient(NetStreamProducer<string, NetStreamTelemetryEvent> producer)
        {
            _producer = producer;
        }

        public async Task SendAsync(NetStreamTelemetryEvent telemetryEvent, CancellationToken token)
        {
            await _producer.ProduceAsync(telemetryEvent.StreamProcessorName, telemetryEvent);
        }
    }
}
