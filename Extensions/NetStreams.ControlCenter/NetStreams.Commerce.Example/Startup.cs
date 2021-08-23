using Confluent.Kafka;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NetStreams.Commerce.Example.Events;
using NetStreams.Commerce.Example.StreamProcessors;
using NetStreams.Serialization;

namespace NetStreams.Commerce.Example
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<FullfillOrderStreamProcessor>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NetStreams.Commerce.Example", Version = "v1" });
            });

            services.AddScoped<IMessageProducer<string, OrderSubmitted>>(cfg =>
            {
                ProducerBuilder<string, OrderSubmitted> producerBuilder = new ProducerBuilder<string, OrderSubmitted>(new ProducerConfig()
                {
                    BootstrapServers = "localhost:9092"
                })
                .SetValueSerializer(new HeaderSerializationStrategy<OrderSubmitted>());

                var netStreamProducer = new NetStreamProducer<string, OrderSubmitted>(
                    "Orders.Submitted",
                    producerBuilder.Build());

                return netStreamProducer;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetStreams.Commerce.Example v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
