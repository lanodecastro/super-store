using SuperStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperStore.Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IList<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product>();
            _products.Add(new Product(1,"Echo Dot (4ª Geração): Smart Speaker com Alexa - Cor Preta", 379.5m, 50));
            _products.Add(new Product(2,"Fone de ouvido sem fio QCY T13 TWS Bluetooth 5.1 ", 128, 4));
            _products.Add(new Product(3,"TicWatch Pro 3 Ultra GPS smartwatch ", 1299, 40));
            _products.Add(new Product(4,"5G WiFi Projetor", 631.89m, 10));

        }
        public IList<Product> All => _products;

        public Product Get(int productId)
        {
            return _products.FirstOrDefault(x => x.Id == productId);
        }
    }
}
