using MediatR.Pipeline;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SuperStore.Domain.Commands.CreateOrderPipe.Steps
{
    public class LogStep : IRequestPreProcessor<CreateOrderRequest>
    {
        public Task Process(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now}");
            return Task.CompletedTask;
        }
    }
}
