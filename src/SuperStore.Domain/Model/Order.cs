using System;
using System.Collections.Generic;

namespace SuperStore.Domain.Model
{
    public class Order
    {
        public string Id { get; private set; }
        public DateTime Date { get; private set; }
        public User User { get; private set; }
        public IList<OrderItem> Items { get; private set; }
    }
}
