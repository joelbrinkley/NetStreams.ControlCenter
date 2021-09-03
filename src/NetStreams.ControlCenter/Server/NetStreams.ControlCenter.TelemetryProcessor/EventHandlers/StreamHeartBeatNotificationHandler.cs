using MediatR;
using NetStreams.ControlCenter.TelemetryProcessor.Models;
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

        public Task Handle(StreamHeartBeatNotification notification, CancellationToken cancellationToken)
        {
            //TODO
            return Task.CompletedTask;
        }
    }
}
