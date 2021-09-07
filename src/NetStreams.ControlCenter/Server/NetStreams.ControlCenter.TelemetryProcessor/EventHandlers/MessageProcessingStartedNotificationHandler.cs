using MediatR;
using NetStreams.ControlCenter.TelemetryProcessor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.TelemetryProcessor.EventHandlers
{
    public class MessageProcessingStartedNotificationHandler : INotificationHandler<MessageProcessingStartedNotification>
    {
        private readonly IStreamProcessorRepository _streamProcessorRepository;
        private readonly IMessageRepository _messageRepository;

        public MessageProcessingStartedNotificationHandler(IStreamProcessorRepository streamProcessorRepository, IMessageRepository messageRepository)
        {
            _streamProcessorRepository = streamProcessorRepository;
            _messageRepository = messageRepository;
        }

        public async Task Handle(MessageProcessingStartedNotification notification, CancellationToken cancellationToken)
        {
            var streamProcessor = await _streamProcessorRepository.GetAsync(notification.StreamProcessorName, cancellationToken);

            if (streamProcessor == null) return;

            var consumedMessage = new ConsumedMessage()
            {
                Id = notification.ConsumeContextId,
                Body = JsonConvert.SerializeObject(notification.Message),
                Key = JsonConvert.SerializeObject(notification.Key),
                StartedOn = notification.OccurredOn,
                StreamProcessorId = streamProcessor.Id,
            };

            await _messageRepository.AddAsync(consumedMessage, cancellationToken);
        }

    }
}
