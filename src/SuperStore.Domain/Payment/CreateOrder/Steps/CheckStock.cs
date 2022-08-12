using MediatR;
using SuperStore.Domain.Payment.CreateOrder;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuperStore.Domain.Commands.CreateOrderPipe.Steps
{
    public class CheckStock : IPipelineBehavior<CreateOrderCommand, CreateOrderResponse>
    {
        private readonly CreateOrderContext _context;
        public CheckStock(CreateOrderContext context)
        {
            _context = context;
        }

        public Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<CreateOrderResponse> next)
        {
            var response = new CreateOrderResponse();

            foreach (var item in request.Items)
            {
                var product = _context.Products.First(x => x.Id == item.ProductId);

                if (product.AvailableQuantity < item.Amount)
                {
                    response.AddNotification("invalid_amount", $"Amount is less than available stock for {product.Description}");
                    break;
                }
            }

            if (!response.IsValid)
                return Task.FromResult(response);

            Console.WriteLine("CheckStock ok;");

            return next();


        }
    }
}
