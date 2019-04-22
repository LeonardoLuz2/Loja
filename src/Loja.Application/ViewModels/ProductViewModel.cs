using System;
using System.ComponentModel.DataAnnotations;

namespace Loja.Application.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(200, ErrorMessage = "O Nome deve ter entre 2 e 200 caracteres.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Preço é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency, ErrorMessage = "O Valor deve estar em um formato válido.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "A Quantidade é obrigatória.")]
        [Display(Name = "Quantity")]
        public int QuantityOnHand { get; set; }
    }
}
