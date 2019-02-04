using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Loja.Application.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(200, ErrorMessage = "O Nome deve ter entre 2 e 200 caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Valor é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency, ErrorMessage = "O Valor deve estar em um formato válido.")]
        [DisplayName("Preço Unitário")]
        public decimal PrecoUnitario { get; set; }
    }
}
