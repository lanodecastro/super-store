using MediatR;
using SuperStore.Domain.Commands.CreateOrder;
using SuperStore.Domain.Model.Payment;
using System.Collections.Generic;

namespace SuperStore.Domain.Commands.CreateOrderPipe
{
    public class CreateOrderRequest : IRequest<CreateOrderResponse>
    {
        public int UserId { get; set; }
        public IList<OrderItemRequest> Items { get; set; }
        public PaymentType PaymentType { get; set; }

        public CreateOrderRequest()
        {
            Items = new List<OrderItemRequest>();
        }

    }
}
