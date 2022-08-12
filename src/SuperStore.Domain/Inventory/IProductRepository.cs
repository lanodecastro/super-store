using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperStore.Domain.Inventory
{
    public interface IProductRepository
    {
        Product Get(int productId);
    }
}
