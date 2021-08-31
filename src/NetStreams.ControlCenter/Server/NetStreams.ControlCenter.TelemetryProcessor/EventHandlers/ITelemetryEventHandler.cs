using NetStreams.Telemetry;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.TelemetryProcessor.EventHandlers
{
    public interface ITelemetryEventHandler
    {
        Task HandleAsync(NetStreamsTelemetryEvent message);
    }
}