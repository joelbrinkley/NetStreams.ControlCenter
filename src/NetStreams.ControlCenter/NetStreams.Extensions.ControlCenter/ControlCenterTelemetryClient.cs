using Confluent.Kafka;
using NetStreams.Telemetry;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetStreams.Extensions.ControlCenter
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
