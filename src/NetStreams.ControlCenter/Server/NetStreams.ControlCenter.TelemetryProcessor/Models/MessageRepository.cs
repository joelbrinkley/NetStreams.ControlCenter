using Microsoft.EntityFrameworkCore;
using NetStreams.ControlCenter.TelemetryProcessor.Infrastructure.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.TelemetryProcessor.Models
{
    public class MessageRepository : IMessageRepository
    {
        private readonly TelemetryDbContext _dbContext;

        public MessageRepository(TelemetryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(ConsumedMessage consumedMessage, CancellationToken cancellationToken)
        {
            _dbContext.ConsumedMessages.Add(consumedMessage);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<ConsumedMessage> GetAsync(Guid consumeContextId, CancellationToken cancellationToken)
        {
            return await _dbContext.ConsumedMessages.FirstOrDefaultAsync(message => message.Id == consumeContextId, cancellationToken);
        }

        public async Task UpdateAsync(ConsumedMessage message, CancellationToken cancellationToken)
        {
            _dbContext.ConsumedMessages.Update(message);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
