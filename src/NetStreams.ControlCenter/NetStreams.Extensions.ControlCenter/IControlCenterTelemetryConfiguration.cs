using NetStreams.Authentication;

namespace NetStreams.Extensions.ControlCenter
{
    public interface IControlCenterTelemetryConfiguration
    {
        string TelemetryTopic { get; }
        string BootstrapServers { get; }
        AuthenticationMethod AuthenticationMethod { get; }
    }
}