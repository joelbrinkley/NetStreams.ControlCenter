using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NetStreams.ControlCenter.TelemetryProcessor.Configuration;
using NetStreams.ControlCenter.TelemetryProcessor.EventHandlers;
using NetStreams.Telemetry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.TelemetryProcessor
{
    public class TelemetryStreamProcessor : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly ITelemetryEventHandler _telemetryEventHandler;
        private INetStream _stream;

        public TelemetryStreamProcessor(IConfiguration configuration, ITelemetryEventHandler telemetryEventHandler)
        {
            _configuration = configuration;
            _telemetryEventHandler = telemetryEventHandler;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var streamConfiguration = _configuration.GetSection("NetStreamTelemetryStreamProcessor")?.Get<StreamConfiguration>();

            if (streamConfiguration == null) throw new Exception("NetStreamTelemetryStreamProcessor configuration is not defined.");

            _stream = new NetStreamBuilder<string, dynamic>(cfg =>
            {
                cfg.BootstrapServers = streamConfiguration.BootstrapServers;
                cfg.ConsumerGroup = streamConfiguration.ConsumerGroup;
                cfg.ContinueOnError = true;
                cfg.AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
            })
            .Stream(streamConfiguration.From)
            .HandleAsync(async context => await _telemetryEventHandler.HandleAsync(context.Message))
            .OnError(err => Console.WriteLine("Err: skipping message."))
            .Build();

            return _stream.StartAsync(stoppingToken);
        }
    }
}
