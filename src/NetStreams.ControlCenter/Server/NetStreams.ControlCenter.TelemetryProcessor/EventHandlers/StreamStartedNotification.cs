using MediatR;
using NetStreams.Telemetry.Events;


namespace NetStreams.ControlCenter.TelemetryProcessor.EventHandlers
{
    public class StreamStartedNotification : StreamStarted, INotification
    {
        public StreamStartedNotification()
        {

        }
    }
}
