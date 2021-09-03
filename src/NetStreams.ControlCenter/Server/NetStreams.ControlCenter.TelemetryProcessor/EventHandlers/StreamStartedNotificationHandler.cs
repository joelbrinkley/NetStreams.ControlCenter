using MediatR;
using NetStreams.ControlCenter.TelemetryProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.TelemetryProcessor.EventHandlers
{
    public class StreamStartedNotificationHandler : INotificationHandler<StreamStartedNotification>
    {
        private readonly IStreamProcessorRepository _streamProcessorRepository;

        public StreamStartedNotificationHandler(IStreamProcessorRepository streamProcessorRepository)
        {
            _streamProcessorRepository = streamProcessorRepository;
        }

        public async Task Handle(StreamStartedNotification notification, CancellationToken cancellationToken)
        {
            var streamProcessor = await _streamProcessorRepository.GetAsync(notification.StreamProcessorName, cancellationToken);

            if(streamProcessor != null)
            {
                streamProcessor.Running = true;
                streamProcessor.LastStarted = notification.OccurredOn;
                await _streamProcessorRepository.UpdateAsync(streamProcessor, cancellationToken);
            }
            else
            {
                streamProcessor = new StreamProcessor()
                {
                    Name = notification.StreamProcessorName,
                    LastStarted = notification.OccurredOn,
                    Running = true,
                    Id = Guid.NewGuid().ToString()
                };
                await _streamProcessorRepository.AddAsync(streamProcessor, cancellationToken);
            }
        }
    }
}
