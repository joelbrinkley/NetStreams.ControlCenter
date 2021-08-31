using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.TelemetryProcessor.Models
{
    public interface IStreamProcessorRepository
    {
        Task<StreamProcessor> GetAsync(string name, CancellationToken token);
    }
}
