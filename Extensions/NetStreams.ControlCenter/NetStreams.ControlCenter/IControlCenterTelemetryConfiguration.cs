using NetStreams.Authentication;

namespace NetStreams.ControlCenter
{
    public interface IControlCenterTelemetryConfiguration
    {
        string TelemetryTopic { get; }
        string BootstrapServers { get; }
        AuthenticationMethod AuthenticationMethod { get; }
    }
}