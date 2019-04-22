using Loja.Domain.Commands.Product;

namespace Loja.Domain.Validations.Product
{
    public class UpdateProductValidation : ProductValidation<UpdateProductCommand>
    {
        public UpdateProductValidation()
        {
            ValidateId();
            ValidateName();
            ValidatePrice();
            ValidateQuantityOnHand();
        }
    }
}
