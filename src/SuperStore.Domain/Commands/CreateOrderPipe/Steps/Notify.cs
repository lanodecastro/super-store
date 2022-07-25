using MediatR;
using SuperStore.Infra.Services.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SuperStore.Domain.Commands.CreateOrderPipe.Steps
{
    public class Notify : IPipelineBehavior<CreateOrderRequest, CreateOrderResponse>
    {
        private readonly IMailService _mailService;
        private readonly CreateOrderContext _context;
        public Notify(IMailService mailService, CreateOrderContext context)
        {
            _mailService = mailService;
            _context = context;
        }

        public Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<CreateOrderResponse> next)
        {
            _mailService.Send(_context.User.Email);

            var response = new CreateOrderResponse();
            response.OrderId = Guid.NewGuid();

            Console.WriteLine("Notify ok;");

            return Task.FromResult(response);

        }
    }
}
