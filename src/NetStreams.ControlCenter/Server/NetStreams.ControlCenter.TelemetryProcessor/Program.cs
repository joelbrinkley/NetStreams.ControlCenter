using System;
using System.IO;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetStreams.ControlCenter.Infrastructure.EntityFrameworkCore;
using NetStreams.ControlCenter.Models.Abstractions;
using NetStreams.ControlCenter.TelemetryProcessor;
using NetStreams.ControlCenter.TelemetryProcessor.EventHandlers;

namespace NetStreams.ControlCenter.Streams
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateHostBuilder(args)
                    .Build()
                    .Run();
            }
            catch (Exception e)
            {
                Console.WriteLine("An unexpected error occurred starting the host.");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
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
                    services.AddScoped<IMessageRepository, MessageRepository>();
                    services.AddHostedService<TelemetryStreamProcessor>();
                });
    }
}
