using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.Models.Abstractions
{
    public interface IMessageRepository
    {
        Task AddAsync(ConsumedMessage consumedMessage, CancellationToken cancellationToken);
        Task<ConsumedMessage> GetAsync(Guid consumeContextId, CancellationToken cancellationToken);
        Task UpdateAsync(ConsumedMessage message, CancellationToken cancellationToken);
    }
}
