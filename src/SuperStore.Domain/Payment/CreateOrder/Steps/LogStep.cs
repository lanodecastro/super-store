using MediatR.Pipeline;
using SuperStore.Domain.Payment.CreateOrder;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SuperStore.Domain.Commands.CreateOrderPipe.Steps
{
    public class LogStep : IRequestPreProcessor<CreateOrderCommand>
    {
        public Task Process(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now}");
            return Task.CompletedTask;
        }
    }
}
