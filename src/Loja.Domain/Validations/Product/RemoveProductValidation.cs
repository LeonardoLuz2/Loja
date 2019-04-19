using Loja.Domain.Commands.Product;
using System;
using System.Collections.Generic;
using System.Text;

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
