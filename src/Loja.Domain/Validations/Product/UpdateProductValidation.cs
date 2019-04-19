using Loja.Domain.Commands.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.Validations.Product
{
    public class UpdateProductValidation : ProductValidation<UpdateProductCommand>
    {
        public UpdateProductValidation()
        {
            ValidateId();
            ValidateName();
            ValidatePrice();
        }
    }
}
