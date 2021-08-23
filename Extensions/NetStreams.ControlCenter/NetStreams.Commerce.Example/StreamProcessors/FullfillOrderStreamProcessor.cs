
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NetStreams.Authentication;
using NetStreams.Commerce.Example.Configuration;
using NetStreams.Commerce.Example.Events;
using NetStreams.ControlCenter;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetStreams.Commerce.Example.StreamProcessors
{
    public class FullfillOrderStreamProcessor : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private INetStream _stream;

        public FullfillOrderStreamProcessor(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var streamConfiguration = _configuration.GetSection("OrderFullfilmentStreamProcessor")?.Get<StreamConfiguration>();

            if (streamConfiguration == null) throw new Exception("OrderFullfilmentStreamProcessor configuration is not defined.");

            _stream = new NetStreamBuilder<string, OrderSubmitted>(cfg =>
            {
                cfg.BootstrapServers = streamConfiguration.BootstrapServers;
                cfg.ConsumerGroup = streamConfiguration.ConsumerGroup;
                cfg.ContinueOnError = false;
                cfg.SendTelemetryToControlCenter(controlCenterConfig =>
                {
                    controlCenterConfig.BootstrapServers = streamConfiguration.BootstrapServers;
                    controlCenterConfig.TelemetryTopic = "netstreams.controlcenter.telemetry";
                    controlCenterConfig.AuthenticationMethod = new PlainTextAuthentication();
                });
                cfg.AddTopicConfiguration(ordersSubmitted =>
                {
                    ordersSubmitted.Name = "Orders.Submitted";
                    ordersSubmitted.Partitions = 2;
                });
                cfg.AddTopicConfiguration(ordersFullfilled =>
                {
                    ordersFullfilled.Name = "Orders.Fullfilled";
                    ordersFullfilled.Partitions = 2;
                });
            })
            .Stream(streamConfiguration.From)
            .Transform(context =>
            {
                //do fulfillment logic
                return new OrderFullfilled
                {
                    FullfillmentId = Guid.NewGuid().ToString(),
                    OrderId = context.Message.OrderId
                };
            })
            .ToTopic<string, OrderFullfilled>(streamConfiguration.To, orderFulfilled => orderFulfilled.OrderId)
            .Build();

            return _stream.StartAsync(stoppingToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await _stream.StopAsync(cancellationToken);

            return base.StopAsync(cancellationToken);
        }
    }
}
