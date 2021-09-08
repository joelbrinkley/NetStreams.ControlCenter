using Microsoft.EntityFrameworkCore;
using NetStreams.ControlCenter.TelemetryProcessor.Models;

namespace NetStreams.ControlCenter.TelemetryProcessor.Infrastructure.EntityFrameworkCore
{
    public class TelemetryDbContext : DbContext
    {
        public DbSet<StreamProcessor> StreamProcessors { get; set; }
        public DbSet<ConsumedMessage> ConsumedMessages { get; set; }

        public TelemetryDbContext(DbContextOptions<TelemetryDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StreamProcessor>()
                .HasKey(model => model.Id);

            modelBuilder.Entity<StreamProcessor>().HasIndex(model => model.Name).IsUnique();

            modelBuilder.Entity<StreamProcessor>().HasMany(model => model.StreamPartitions);

            modelBuilder.Entity<StreamPartition>().ToTable("StreamPartitions").HasKey(model => model.Id);

            modelBuilder.Entity<ConsumedMessage>().HasKey(model => model.Id);


        }
    }
}
