using SuperStore.Domain.Model;
using System.Collections.Generic;

namespace SuperStore.Domain.Commands.CreateOrderPipe
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
