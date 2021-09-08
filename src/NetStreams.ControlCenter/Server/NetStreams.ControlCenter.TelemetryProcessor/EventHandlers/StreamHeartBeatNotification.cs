using MediatR;
using NetStreams.Telemetry.Events;

namespace NetStreams.ControlCenter.TelemetryProcessor.EventHandlers
{
    public class StreamHeartBeatNotification: StreamHeartBeat, INotification
    {
    }
}
