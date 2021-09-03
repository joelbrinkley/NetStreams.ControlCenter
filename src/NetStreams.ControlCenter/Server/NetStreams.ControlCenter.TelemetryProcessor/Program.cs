using System;
using System.IO;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetStreams.ControlCenter.TelemetryProcessor;
using NetStreams.ControlCenter.TelemetryProcessor.EventHandlers;
using NetStreams.ControlCenter.TelemetryProcessor.Infrastructure.EntityFrameworkCore;
using NetStreams.ControlCenter.TelemetryProcessor.Models;

namespace NetStreams.ControlCenter.Streams
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var host = CreateHostBuilder(args).Build();
                using (var serviceScope = host.Services.CreateScope())
                {
                    host.Run();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("An unexpected error occurred starting the host.");
            }
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
                    services.AddMediatR(typeof(StreamStartedNotification));
                    services.AddTelemetryDbContext();
                    services.AddScoped<IStreamProcessorRepository, StreamProcessorRepository>();
                    services.AddHostedService<TelemetryStreamProcessor>();
                });
    }
}
