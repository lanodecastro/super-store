using SuperStore.Domain.Commands.CreateOrderPipe.Steps;
using SuperStore.Domain.Workflow;

namespace SuperStore.Domain.Payment.CreateOrder
{
    public class CreateOrderWorkflow : PipelineBehaviorWorkflow
    {
        public CreateOrderWorkflow()
        {
            For<CreateOrderCommand, CreateOrderResponse, CreateOrderContext>()
                .AddStep<ValidateRequest>()
                .AddStep<RetriveData>()
                .AddStep<CheckStock>()
                .AddStep<Pay>()
                .AddStep<Notify>();

        }
    }
}
