using Loja.Application.Interfaces;
using Loja.Application.ViewModels;
using Loja.Site.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Loja.Tests.UnitTests
{
    public class ProdutoUnitTest
    {
        public Mock<IProdutoAppService> _produtoAppService;

        public ProdutoUnitTest()
        {
            _produtoAppService = new Mock<IProdutoAppService>();
        }

        [Fact]
        private void Index_ListaProdutos()
        {
            // Arrange
            _produtoAppService.Setup(m => m.GetAll()).Returns(GetListaProdutos());
            var controller = new ProdutoController(_produtoAppService.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ProdutoViewModel>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, ((List<ProdutoViewModel>)model).Count);
        }

        [Fact]
        private void Details_Produto()
        {
            // Arrange
            var guid = Guid.Parse("8fe7d37b-83d5-4999-b0ea-45d28114a3cd");
            _produtoAppService.Setup(m => m.GetById(guid))
                .Returns(GetListaProdutos().FirstOrDefault(p => p.Id == guid));

            var controller = new ProdutoController(_produtoAppService.Object);

            // Act
            var result = controller.Details(guid);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ProdutoViewModel>(
                viewResult.ViewData.Model);

            Assert.Equal("Pipoca", model.Nome);
            Assert.Equal(4, model.PrecoUnitario);
            Assert.Equal(guid, model.Id);
        }

        private List<ProdutoViewModel> GetListaProdutos()
        {
            var produtos = new List<ProdutoViewModel>
            {
                new ProdutoViewModel
                {
                    Id = Guid.Parse("4177c380-74cc-4b59-bc03-04c07dd768b3"),
                    Nome = "Chocolate",
                    PrecoUnitario = 5
                },
                new ProdutoViewModel
                {   Id = Guid.Parse("8fe7d37b-83d5-4999-b0ea-45d28114a3cd"),
                    Nome = "Pipoca",
                    PrecoUnitario = 4
                }
            };

            return produtos;
        }
    }
}
