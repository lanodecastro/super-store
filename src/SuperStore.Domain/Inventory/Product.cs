using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperStore.Domain.Inventory
{
    public class Product
    {
        public int Id { get; set; }
        public int AvailableQuantity { get; set; }
        public string Description { get; set; }
    }
}
