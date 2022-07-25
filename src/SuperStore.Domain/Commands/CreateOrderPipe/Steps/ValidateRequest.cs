using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SuperStore.Domain.Commands.CreateOrderPipe.Steps
{
    public class ValidateRequest : IPipelineBehavior<CreateOrderRequest, CreateOrderResponse>
    {
        public Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<CreateOrderResponse> next)
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
