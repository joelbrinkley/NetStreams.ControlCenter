using Confluent.Kafka;
using NetStreams.Configuration;
using NetStreams.Serialization;
using NetStreams.Telemetry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NetStreams.ControlCenter
{
    public static class NetStreamBuilderExtensions
    {
        public static void SendTelemetryToControlCenter<TKey, TMessage>(this INetStreamConfigurationBuilderContext<TKey, TMessage> builder, Action<ControlCenterTelemetryConfiguration> setup)
        {
            var config = new ControlCenterTelemetryConfiguration();
            setup(config);

            ProducerBuilder<string, NetStreamsTelemetryEvent> producerBuilder = new ProducerBuilder<string, NetStreamsTelemetryEvent>(config.ToProducerConfig())
                .SetValueSerializer(new HeaderSerializationStrategy<NetStreamsTelemetryEvent>());

            var netStreamProducer = new NetStreamProducer<string, NetStreamsTelemetryEvent>(
                config.TelemetryTopic,
                producerBuilder.Build());

            builder.SendTelemetry(new ControlCenterTelemetryClient(netStreamProducer));
        }
    }
}
