using SuperStore.Domain.Account;
using SuperStore.Domain.Inventory;
using System;

namespace SuperStore.Domain.Payment
{
    public class OrderItem
    {
        public Guid Id { get; private set; }
        public Product Product { get; private set; }
        public Order Order { get; private set; }
        public User User { get; private set; }
        public int Amount { get; private set; }
    }
}