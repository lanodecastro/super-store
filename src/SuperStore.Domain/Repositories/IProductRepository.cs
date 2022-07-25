using SuperStore.Domain.Model;
using System;
using System.Collections.Generic;

namespace SuperStore.Domain.Repositories
{
    public interface IProductRepository
    {
        public Product Get(int productId);
        IList<Product> All { get; }

    }
}
