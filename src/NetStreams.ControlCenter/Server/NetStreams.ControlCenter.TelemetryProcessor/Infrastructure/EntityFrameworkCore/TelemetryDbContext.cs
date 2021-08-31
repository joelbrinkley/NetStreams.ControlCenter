using Microsoft.EntityFrameworkCore;
using NetStreams.ControlCenter.TelemetryProcessor.Models;

namespace NetStreams.ControlCenter.TelemetryProcessor.Infrastructure.EntityFrameworkCore
{
    public class TelemetryDbContext : DbContext
    {
        public DbSet<StreamProcessor> StreamProcessors { get; set; }

        public TelemetryDbContext(DbContextOptions<TelemetryDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StreamProcessor>()
                .HasKey(model => model.Id);

            modelBuilder.Entity<StreamProcessor>().HasIndex(model => model.Name).IsUnique();
            
        }
    }
}
