using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace SuperStore.Domain.Workflow
{
    public class PipelineBehaviorWorkflow : IPipelineBehaviorWorkflow, IStep
    {
        public IList<ServiceDescriptor> Steps { get; }
        public Type Context { get; private set; }

        private Type _typeOfService;

        public PipelineBehaviorWorkflow()
        {
            Steps = new List<ServiceDescriptor>();
        }
        public IStep For<TRequest, TResponse, TContext>()
        {
            _typeOfService = typeof(IPipelineBehavior<TRequest, TResponse>);
            Context = typeof(TContext);
            return this;
        }
        public IStep AddStep<TImplementation>()
        {
            Steps.Add(new ServiceDescriptor(_typeOfService, typeof(TImplementation), ServiceLifetime.Scoped));
            return this;
        }

    }
}
