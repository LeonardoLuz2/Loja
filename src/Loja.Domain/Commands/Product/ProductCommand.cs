using Loja.Domain.Core.Commands;
using System;

namespace Loja.Domain.Commands.Product
{
    public abstract class ProductCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }

        public decimal Price { get; protected set; }
    }
}
