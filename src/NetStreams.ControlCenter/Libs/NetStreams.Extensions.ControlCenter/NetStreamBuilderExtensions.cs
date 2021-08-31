using Confluent.Kafka;
using NetStreams.Configuration;
using NetStreams.Serialization;
using NetStreams.Telemetry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NetStreams.Extensions.ControlCenter
{
    public static class NetStreamBuilderExtensions
    {
        public static void SendTelemetryToControlCenter<TKey, TMessage>(this INetStreamConfigurationBuilderContext<TKey, TMessage> builder, Action<ControlCenterTelemetryConfiguration> setup)
        {
            var config = new ControlCenterTelemetryConfiguration();
            setup(config);

            ProducerBuilder<string, NetStreamTelemetryEvent> producerBuilder = new ProducerBuilder<string, NetStreamTelemetryEvent>(config.ToProducerConfig())
                .SetValueSerializer(new HeaderSerializationStrategy<NetStreamTelemetryEvent>());

            var netStreamProducer = new NetStreamProducer<string, NetStreamTelemetryEvent>(
                config.TelemetryTopic,
                producerBuilder.Build());

            builder.SendTelemetry(new ControlCenterTelemetryClient(netStreamProducer));
        }
    }
}
