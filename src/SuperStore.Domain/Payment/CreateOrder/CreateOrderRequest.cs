using MediatR;
using SuperStore.Domain.Model.Payment;
using System.Collections.Generic;

namespace SuperStore.Domain.Payment.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderResponse>
    {
        public int UserId { get; set; }
        public IList<OrderItemRequest> Items { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }

        public CreateOrderCommand()
        {
            Items = new List<OrderItemRequest>();
        }

    }
}
