using Loja.Domain.Commands.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.Validations.Product
{
    public class RegisterProductValidation : ProductValidation<RegisterProductCommand>
    {
        public RegisterProductValidation()
        {
            ValidateName();
            ValidatePrice();
        }
    }
}
