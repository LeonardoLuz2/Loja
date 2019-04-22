using Loja.Domain.Commands.Product;

namespace Loja.Domain.Validations.Product
{
    public class RemoveProductValidation : ProductValidation<RemoveProductCommand>
    {
        public RemoveProductValidation()
        {
            ValidateId();
        }
    }
}
