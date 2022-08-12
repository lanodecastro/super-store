using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using SuperStore.Domain.Payment.CreateOrder;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SuperStore.Domain.Commands.CreateOrderPipe.Steps
{
    public class ValidateRequest : IPipelineBehavior<CreateOrderCommand, CreateOrderResponse>
    {
        public Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<CreateOrderResponse> next)
        {
            var response = new CreateOrderResponse();

            response.AddNotifications(new Contract<Notification>()
               .Requires()
               .IsNotNull(request.UserId, "invalid_user_id", "Invalid UserId")
               .IsNotEmpty(request.Items, "items_is_not_empty", "Items cannot be empty")
           );

            if (!response.IsValid)
                return Task.FromResult(response);

            Console.WriteLine("Validate ok;");

            return next();
        }
    }
}
