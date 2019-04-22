using Loja.Domain.Validations.Product;
using System;

namespace Loja.Domain.Commands.Product
{
    public class UpdateProductCommand : ProductCommand
    {
        public UpdateProductCommand(Guid id, string name, decimal price, int quantityOnHand)
        {
            Id = id;
            Name = name;
            Price = price;
            QuantityOnHand = quantityOnHand;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
