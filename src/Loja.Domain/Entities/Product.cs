using Loja.Domain.Core.Entities;
using System;

namespace Loja.Domain.Entities
{
    public class Product : Entity
    {
        public Product(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        protected Product() { }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
    }
}
