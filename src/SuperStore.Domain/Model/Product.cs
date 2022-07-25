using System;

namespace SuperStore.Domain.Model
{
    public class Product
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int AvailableQuantity { get; private set; }  
        public Product(int id,string description, decimal price, int availableQuantity)
        {
            Id = id;
            Description = description;
            Price = price;
            AvailableQuantity = availableQuantity;
        }

    }
}
