using System;

namespace SuperStore.Domain.Commands.CreateOrder
{
    public class OrderItemRequest
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
