using Loja.Domain.Core.Entities;
using System;

namespace Loja.Domain.Entities
{
    public class Product : Entity
    {
        public Product(Guid id, string name, decimal price, int quantityOnHand)
        {
            Id = id;
            Name = name;
            Price = price;
            QuantityOnHand = quantityOnHand;
        }

        protected Product() { }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int QuantityOnHand { get; private set; }

        public void UpdateQuantityOnHand(int amount)
        {
            QuantityOnHand -= amount;
        }
    }
}
