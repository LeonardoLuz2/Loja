using FluentValidation;
using Loja.Domain.Commands.Product;
using System;

namespace Loja.Domain.Validations.Product
{
    public abstract class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
    {
        protected void ValidateId()
        {
            RuleFor(p => p.Id)
                .NotEqual(Guid.Empty).WithMessage("Id inválido.");
        }

        protected void ValidateName()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O Nome é obrigatório.")
                .Length(2, 200).WithMessage("O Nome deve ter entre 2 e 200 caracteres.");
        }

        protected void ValidatePrice()
        {
            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(.1m).WithMessage("O preço deve ser maior que zero.");
        }

        protected void ValidateQuantityOnHand()
        {
            RuleFor(p => p.QuantityOnHand)
                .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.");
        }
    }
}
