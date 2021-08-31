using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetStreams.ControlCenter.TelemetryProcessor;
using NetStreams.ControlCenter.TelemetryProcessor.EventHandlers;

namespace NetStreams.ControlCenter.Streams
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(configHost =>
                {
                    configHost.SetBasePath(Directory.GetCurrentDirectory());
                    configHost.AddJsonFile("appsettings.json", optional: false);
                    configHost.AddEnvironmentVariables();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<ITelemetryEventHandler, TelemetryEventHandler>();
                    services.AddHostedService<TelemetryStreamProcessor>();
                });

    }
}
