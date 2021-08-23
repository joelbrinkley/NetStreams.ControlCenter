using Confluent.Kafka;
using NetStreams.Authentication;

namespace NetStreams.ControlCenter
{
    public class ControlCenterTelemetryConfiguration : IControlCenterTelemetryConfiguration
    {
        public string BootstrapServers { get; set; } = "localhost:9092";

        public AuthenticationMethod AuthenticationMethod { get; set; } = new PlainTextAuthentication();

        public string TelemetryTopic { get; set; } = "netstreams.controlcenter.telemetry";
    }

    internal static class ControlCenterTelemetryConfigurationExtentions
    {
        internal static ProducerConfig ToProducerConfig(this IControlCenterTelemetryConfiguration config)
        {
            var producerConfig = new ProducerConfig()
            {
                BootstrapServers = config.BootstrapServers,
            };
            config.AuthenticationMethod.Apply(producerConfig);
            return producerConfig;
        }
    }
}