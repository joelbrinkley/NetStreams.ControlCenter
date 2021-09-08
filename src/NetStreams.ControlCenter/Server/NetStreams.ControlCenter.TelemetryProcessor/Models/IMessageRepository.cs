using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.TelemetryProcessor.Models
{
    public interface IMessageRepository
    {
        Task AddAsync(ConsumedMessage consumedMessage, CancellationToken cancellationToken);
        Task<ConsumedMessage> GetAsync(Guid consumeContextId, CancellationToken cancellationToken);
        Task UpdateAsync(ConsumedMessage message, CancellationToken cancellationToken);
    }
}
