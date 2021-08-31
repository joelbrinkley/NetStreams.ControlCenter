using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NetStreams.ControlCenter.TelemetryProcessor.Infrastructure.EntityFrameworkCore
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddTelemetryDbContext(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            var sqlConnectionString = configuration["SqlConnectionString"];
            services.AddDbContext<TelemetryDbContext>(
                options => options.UseSqlServer(sqlConnectionString,
                x =>
                {
                    x.EnableRetryOnFailure(6, TimeSpan.FromSeconds(2), null);
                }));

            return services;
        }
    }
}
