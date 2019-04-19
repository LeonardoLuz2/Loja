using System;

namespace Loja.Domain.Core.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id= {Id}]";
        }
    }
}
