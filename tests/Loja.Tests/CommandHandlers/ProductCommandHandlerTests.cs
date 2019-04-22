using Loja.Domain.CommandHandlers;
using Loja.Domain.Commands.Product;
using Loja.Domain.Core.Notifications;
using Loja.Domain.Interfaces;
using MediatR;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace Loja.Tests.CommandHandlers
{
    public class ProductCommandHandlerTests
    {
        private ProductCommandHandler productCommandHandler;
        private Mock<IMediator> mockMediator;
        private Mock<IUnitOfWork> mockUow;
        private Mock<IProductRepository> mockProductRepository;
        private Mock<NotificationHandler> mockNotifications;

        public ProductCommandHandlerTests()
        {
            mockMediator = new Mock<IMediator>();
            mockUow = new Mock<IUnitOfWork>();
            mockProductRepository = new Mock<IProductRepository>();
            mockNotifications = new Mock<NotificationHandler>();

            mockUow.Setup(m => m.Commit()).Returns(true);

            productCommandHandler = new ProductCommandHandler(
                        mockUow.Object,
                        mockProductRepository.Object,
                        mockMediator.Object,
                        mockNotifications.Object);
        }

        [Fact]
        public void RegisterProduct_ShouldBeSuccess()
        {
            // Arrange
            var productCommand = new RegisterProductCommand("Pipoca", 10, 5);

            // Act
            var result = productCommandHandler.Handle(productCommand, new CancellationToken());

            // Assert
            Assert.True(result.Result);
        }

        [Fact]
        public void RegisterProduct_ShouldReturnErrorWhenCommandIsInvalid()
        {
            // Arrange
            var productCommand = new RegisterProductCommand("", 0, 0);

            // Act
            var result = productCommandHandler.Handle(productCommand, new CancellationToken());

            // Assert
            Assert.False(result.Result);
        }

        [Fact]
        public void RemoveProduct_ShouldBeSuccess()
        {
            // Arrange
            var productCommand = new RemoveProductCommand(Guid.NewGuid());

            // Act
            var result = productCommandHandler.Handle(productCommand, new CancellationToken());

            // Assert
            Assert.True(result.Result);
        }

        [Fact]
        public void RemoveProduct_ShouldReturnErrorWhenCommandIsInvalid()
        {
            // Arrange
            var productCommand = new RemoveProductCommand(Guid.Empty);

            // Act
            var result = productCommandHandler.Handle(productCommand, new CancellationToken());

            // Assert
            Assert.False(result.Result);
        }

        [Fact]
        public void UpdateProduct_ShouldBeSuccess()
        {
            // Arrange
            var productCommand = new UpdateProductCommand(Guid.NewGuid(), "Pipoca", 4, 5);

            // Act
            var result = productCommandHandler.Handle(productCommand, new CancellationToken());

            // Assert
            Assert.True(result.Result);
        }

        [Fact]
        public void UpdateProduct_ShouldReturnErrorWhenCommandIsInvalid()
        {
            // Arrange
            var productCommand = new UpdateProductCommand(Guid.NewGuid(), "P", 4, 5);

            // Act
            var result = productCommandHandler.Handle(productCommand, new CancellationToken());

            // Assert
            Assert.False(result.Result);
        }
    }
}
