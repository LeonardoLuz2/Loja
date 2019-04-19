using Loja.Application.Interfaces;
using Loja.Application.ViewModels;
using Loja.Domain.Core.Notifications;
using Loja.Site.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Loja.Tests.Controllers
{
    public class ProductControllerTests
    {
        private Mock<IProductAppService> _productAppService;
        private Mock<NotificationHandler> _notifications;

        public ProductControllerTests()
        {
            _productAppService = new Mock<IProductAppService>();
            _notifications = new Mock<NotificationHandler>();
        }

        [Fact]
        public void ProductsIndex()
        {
            // Arrange
            _productAppService.Setup(m => m.GetAll()).Returns(GetProductList());
            var controller = new ProductController(_productAppService.Object, _notifications.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ProductViewModel>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, (model as List<ProductViewModel>).Count);
        }

        [Fact]
        public void ProductDetails()
        {
            // Arrange
            var guid = Guid.Parse("8fe7d37b-83d5-4999-b0ea-45d28114a3cd");
            _productAppService.Setup(m => m.GetById(guid))
                .Returns(GetProductList().FirstOrDefault(p => p.Id == guid));

            var controller = new ProductController(_productAppService.Object, _notifications.Object);

            // Act
            var result = controller.Details(guid);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ProductViewModel>(
                viewResult.ViewData.Model);

            Assert.Equal("Pipoca", model.Name);
            Assert.Equal(4, model.Price);
            Assert.Equal(guid, model.Id);
        }

        [Fact]
        public void RegisterProduct()
        {
            // Arrange
            var productViewModel = new ProductViewModel
            {
                Id = Guid.NewGuid(),
                Name = "Coca-cola",
                Price = 8
            };

            var controller = new ProductController(_productAppService.Object, _notifications.Object);

            // Act
            var result = controller.Create(productViewModel);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void RemoveProduct()
        {
            // Arrange
            var controller = new ProductController(_productAppService.Object, _notifications.Object);

            // Act
            var result = controller.DeleteConfirmed(Guid.Parse("4177c380-74cc-4b59-bc03-04c07dd768b3"));

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        private List<ProductViewModel> GetProductList()
        {
            var products = new List<ProductViewModel>
            {
                new ProductViewModel
                {
                    Id = Guid.Parse("4177c380-74cc-4b59-bc03-04c07dd768b3"),
                    Name = "Chocolate",
                    Price = 5
                },
                new ProductViewModel
                {   Id = Guid.Parse("8fe7d37b-83d5-4999-b0ea-45d28114a3cd"),
                    Name = "Pipoca",
                    Price = 4
                }
            };

            return products;
        }
    }
}
