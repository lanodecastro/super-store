using Microsoft.Extensions.DependencyInjection;
using System;

namespace SuperStore.Domain.Workflow
{
    public static class WorkflowExtensions
    {
        public static void AddWorkFlow<T>(this IServiceCollection services) where T : IPipelineBehaviorWorkflow
        {
            var workflow = Activator.CreateInstance<T>();
            services.Add(new ServiceDescriptor(workflow.Context, Activator.CreateInstance(workflow.Context)));
            foreach (var item in workflow.Steps)
            {
                services.Add(item);
            }
        }
    }
}
