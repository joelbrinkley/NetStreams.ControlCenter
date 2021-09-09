using MediatR;
using NetStreams.ControlCenter.Models;
using NetStreams.ControlCenter.Models.Abstractions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.TelemetryProcessor.EventHandlers
{
    public class MessageProcessingStartedUpdateStreamMetricsNotificationHandler : INotificationHandler<MessageProcessingStartedNotification>
    {
        private readonly IStreamProcessorRepository _streamProcessorRepository;

        public MessageProcessingStartedUpdateStreamMetricsNotificationHandler(IStreamProcessorRepository streamProcessorRepository)
        {
            _streamProcessorRepository = streamProcessorRepository;
        }
        public async  Task Handle(MessageProcessingStartedNotification notification, CancellationToken cancellationToken)
        {
            var streamProcessor = await _streamProcessorRepository.GetAsync(notification.StreamProcessorName, cancellationToken);

            if (streamProcessor == null) return;

            var streamPartition = streamProcessor.StreamPartitions.FirstOrDefault(partition => partition.Partition == notification.Partition);

            if (streamPartition == null)
            {
                streamPartition = new StreamPartition()
                {
                    Id = Guid.NewGuid().ToString(),
                    StreamProcessorId = streamProcessor.Id,
                    Partition = notification.Partition,
                    Offset = notification.Offset,
                    Lag = notification.Lag,
                    LastUpdated = notification.OccurredOn
                };

                streamProcessor.StreamPartitions.Add(streamPartition);
            }
            else
            {
                streamPartition.Lag = notification.Lag;
                streamPartition.Offset = notification.Offset;
                streamPartition.LastUpdated = notification.OccurredOn;
            }
            await _streamProcessorRepository.UpdateAsync(streamProcessor, cancellationToken);
        }
    }
}
