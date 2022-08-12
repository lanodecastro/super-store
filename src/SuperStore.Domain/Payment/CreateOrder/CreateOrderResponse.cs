using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperStore.Domain.Payment.CreateOrder
{
    public class CreateOrderResponse : Notifiable<Notification>
    {
        public Guid OrderId { get; set; }
    }
}
