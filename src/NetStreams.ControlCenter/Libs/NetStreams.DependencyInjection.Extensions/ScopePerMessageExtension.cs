using NetStreams.Configuration;
using System;

namespace NetStreams.ControlCenter.TelemetryProcessor
{
    public static class ScopePerMessageExtension
    {
        public static INetStreamConfigurationBuilderContext<TKey, TMessage> ScopePerMessage<TKey, TMessage>(this INetStreamConfigurationBuilderContext<TKey, TMessage> builder, IServiceProvider services)
        {
            builder.PipelineSteps.Push(new ScopedPipelineBehavior<TKey, TMessage>(services));
            return builder;
        }
    }
}
