using FluentValidation;
using Loja.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O Nome é obrigatório.")
                .Length(2, 200).WithMessage("O Nome deve ter entre 2 e 200 caracteres.");
        }
    }
}
