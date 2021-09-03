using MediatR;
using NetStreams.ControlCenter.TelemetryProcessor.EventHandlers;
using NetStreams.Telemetry;
using NetStreams.Telemetry.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.TelemetryProcessor.Extensions
{
    public static class TelemetryEventExtensions
    {
        public static INotification ToNotification(this NetStreamTelemetryEvent telemetryEvent)
        {
            var type = Type.GetType($"NetStreams.ControlCenter.TelemetryProcessor.EventHandlers.{telemetryEvent.EventName}Notification");
            var obj = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(telemetryEvent), type);
            return (INotification)obj;
        }
    }
}
