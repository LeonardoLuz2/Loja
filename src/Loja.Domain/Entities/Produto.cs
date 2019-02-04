using System;

namespace Loja.Domain.Entities
{
    public class Produto : Entity
    {
        public Produto() { }

        public Produto(string nome, decimal precoUnitario)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            PrecoUnitario = precoUnitario;
        }

        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
