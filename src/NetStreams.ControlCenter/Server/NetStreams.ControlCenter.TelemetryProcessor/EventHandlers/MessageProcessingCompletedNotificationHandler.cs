using MediatR;
using NetStreams.ControlCenter.Models.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.TelemetryProcessor.EventHandlers
{
    public class MessageProcessingCompletedNotificationHandler : INotificationHandler<MessageProcessingCompletedNotification>
    {
        private readonly IMessageRepository _messageRepository;

        public MessageProcessingCompletedNotificationHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task Handle(MessageProcessingCompletedNotification notification, CancellationToken cancellationToken)
        {
            var message = await _messageRepository.GetAsync(notification.ConsumeContextId, cancellationToken);

            if (message == null) return;

            message.Completed = true;
            message.CompletedOn = notification.OccurredOn;
            message.ProcessingDurationSeconds = (message.CompletedOn - message.StartedOn).Value.TotalSeconds;

            await _messageRepository.UpdateAsync(message, cancellationToken);
        }
    }
}
