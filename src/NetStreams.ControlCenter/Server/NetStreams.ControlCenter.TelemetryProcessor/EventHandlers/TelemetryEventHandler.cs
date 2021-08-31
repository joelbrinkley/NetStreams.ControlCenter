using NetStreams.Telemetry;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.TelemetryProcessor.EventHandlers
{
    public class TelemetryEventHandler : ITelemetryEventHandler
    {
        public Task HandleAsync(NetStreamsTelemetryEvent message)
        {
            Console.WriteLine("Message recieved!");
            Console.WriteLine(JsonConvert.SerializeObject(message));
            return Task.CompletedTask;
        }
    }
}
