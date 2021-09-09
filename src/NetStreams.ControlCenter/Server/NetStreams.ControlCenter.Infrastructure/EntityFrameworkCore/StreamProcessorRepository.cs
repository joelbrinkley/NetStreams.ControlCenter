using Microsoft.EntityFrameworkCore;
using NetStreams.ControlCenter.Models;
using NetStreams.ControlCenter.Models.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.Infrastructure.EntityFrameworkCore
{
    public class StreamProcessorRepository : IStreamProcessorRepository
    {
        private readonly TelemetryDbContext _dbContext;

        public StreamProcessorRepository(TelemetryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(StreamProcessor streamProcessor, CancellationToken cancellationToken)
        {
            await _dbContext.StreamProcessors.AddAsync(streamProcessor, cancellationToken);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<StreamProcessor> GetAsync(string name, CancellationToken token)
        {
            return await _dbContext.StreamProcessors
                        .Include(p => p.StreamPartitions)
                        .FirstOrDefaultAsync(sp => name.ToLower() == sp.Name.ToLower(), token);
        }

        public async Task UpdateAsync(StreamProcessor streamProcessor, CancellationToken cancellationToken)
        {
            _dbContext.StreamProcessors.Update(streamProcessor);
            await _dbContext.SaveChangesAsync();
        }
    }
}
