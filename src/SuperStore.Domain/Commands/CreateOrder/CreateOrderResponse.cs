using Flunt.Notifications;
using System;

namespace SuperStore.Domain.Commands.CreateOrder
{
    public class CreateOrderResponse:Notifiable<Notification>
    {
        public Guid OrderId { get; set; }
    }
}
