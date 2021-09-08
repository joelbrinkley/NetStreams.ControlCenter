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
    public class StreamStoppedNotificationHandler : INotificationHandler<StreamStoppedNotification>
    {
        private IStreamProcessorRepository _streamProcessorRepository;

        public StreamStoppedNotificationHandler(IStreamProcessorRepository streamProcessorRepository)
        {
            _streamProcessorRepository = streamProcessorRepository;
        }

        public async Task Handle(StreamStoppedNotification notification, CancellationToken cancellationToken)
        {
            var streamProcessor = await _streamProcessorRepository.GetAsync(notification.StreamProcessorName, cancellationToken);

            if(streamProcessor!= null)
            {
                streamProcessor.Running = false;
                await _streamProcessorRepository.UpdateAsync(streamProcessor, cancellationToken);
            }
        }
    }
}
