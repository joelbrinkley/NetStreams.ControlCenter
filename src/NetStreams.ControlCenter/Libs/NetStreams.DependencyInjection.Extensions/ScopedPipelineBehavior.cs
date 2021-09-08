using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.TelemetryProcessor
{
    public class ScopedPipelineBehavior<TKey, TMessage> : PipelineStep<TKey, TMessage>
    {
        private readonly IServiceProvider _serviceProvider;

        public ScopedPipelineBehavior(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override Task<NetStreamResult> ExecuteAsync(IConsumeContext<TKey, TMessage> consumeContext, CancellationToken token, NetStreamResult result = null)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                return base.ExecuteAsync(consumeContext, token, result);
            }
        }
    }
}
