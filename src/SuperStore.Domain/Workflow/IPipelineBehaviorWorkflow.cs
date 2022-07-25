using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace SuperStore.Domain.Workflow
{
    public interface IPipelineBehaviorWorkflow
    {
        IList<ServiceDescriptor> Steps { get; }
        public Type Context { get; }

        IStep For<TRequest, TResponse,TContext>();

    }
    public interface IStep
    {
        IStep AddStep<TImplementation>();
    }
}
