using Loja.Domain.Validations.Product;
using System;

namespace Loja.Domain.Commands.Product
{
    public class RegisterProductCommand : ProductCommand
    {
        public RegisterProductCommand(string name, decimal price, int quantityOnHand)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            QuantityOnHand = quantityOnHand;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
