using SuperStore.Domain.Account;
using SuperStore.Domain.Inventory;
using System.Collections.Generic;

namespace SuperStore.Domain.Payment.CreateOrder
{
    public class CreateOrderContext
    {
        public User User { get; set; }
        public IList<Product> Products { get; set; }

        public CreateOrderContext()
        {
            Products = new List<Product>();
        }

    }
}
