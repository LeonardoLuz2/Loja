using System;

namespace Loja.Domain.Entities
{
    public class Produto : Entity
    {
        protected Produto() { }

        public string Nome { get; private set; }
        public decimal PrecoUnitario { get; private set; }
    }
}
