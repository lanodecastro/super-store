using SuperStore.Domain.Commands.CreateOrderPipe.Steps;
using SuperStore.Domain.Workflow;

namespace SuperStore.Domain.Commands.CreateOrderPipe
{
    public class CreateOrderWorkflow : PipelineBehaviorWorkflow
    {
        public CreateOrderWorkflow()
        {
            For<CreateOrderRequest, CreateOrderResponse, CreateOrderContext>()
                .AddStep<ValidateRequest>()
                .AddStep<RetriveData>()
                .AddStep<CheckStock>()
                .AddStep<Pay>()
                .AddStep<Notify>();

        }
    }
}
