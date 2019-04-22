using Loja.Domain.Commands.Product;

namespace Loja.Domain.Validations.Product
{
    public class RegisterProductValidation : ProductValidation<RegisterProductCommand>
    {
        public RegisterProductValidation()
        {
            ValidateName();
            ValidatePrice();
            ValidateQuantityOnHand();
        }
    }
}
