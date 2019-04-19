using Loja.Domain.Validations.Product;
using System;

namespace Loja.Domain.Commands.Product
{
    public class RemoveProductCommand : ProductCommand
    {
        public RemoveProductCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
