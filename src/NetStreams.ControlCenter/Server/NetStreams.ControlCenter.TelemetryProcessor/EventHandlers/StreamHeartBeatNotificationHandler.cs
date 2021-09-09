using MediatR;
using NetStreams.ControlCenter.Models.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.TelemetryProcessor.EventHandlers
{
    public class StreamHeartBeatNotificationHandler : INotificationHandler<StreamHeartBeatNotification>
    {
        private readonly IStreamProcessorRepository _streamProcessorRepository;

        public StreamHeartBeatNotificationHandler(IStreamProcessorRepository streamProcessorRepository)
        {
            _streamProcessorRepository = streamProcessorRepository;
        }

        public async Task Handle(StreamHeartBeatNotification notification, CancellationToken cancellationToken)
        {
            var streamProcessor = await _streamProcessorRepository.GetAsync(notification.StreamProcessorName, cancellationToken);
           
            if(streamProcessor != null)
            {
                streamProcessor.LastHeartBeat = notification.OccurredOn;
                await _streamProcessorRepository.UpdateAsync(streamProcessor, cancellationToken);
            }
        }
    }
}
