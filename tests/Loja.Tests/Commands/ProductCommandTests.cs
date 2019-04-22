using Loja.Domain.Commands.Product;
using System;
using Xunit;

namespace Loja.Tests.Commands
{
    public class ProductCommandTests
    {
        [Fact]
        public void RegisterProduct_ShouldReturnErrorWhenNameIsInvalid()
        {
            var command = new RegisterProductCommand("", 10, 5);

            Assert.False(command.IsValid());
        }

        [Fact]
        public void RegisterProduct_ShouldReturnErrorWhenPriceIsInvalid()
        {
            var command = new RegisterProductCommand("Pipoca", .01m, 5);

            Assert.False(command.IsValid());
        }

        [Fact]
        public void RegisterProduct_ShouldBeSuccess()
        {
            var command = new RegisterProductCommand("Pipoca", 10, 5);

            Assert.True(command.IsValid());
        }

        [Fact]
        public void RemoveProduct_ShouldReturnErrorWhenIdIsInvalid()
        {
            var command = new RemoveProductCommand(Guid.Empty);

            Assert.False(command.IsValid());
        }

        [Fact]
        public void RemoveProduct_ShouldBeSuccess()
        {
            var command = new RemoveProductCommand(Guid.NewGuid());

            Assert.True(command.IsValid());
        }


        [Fact]
        public void UpdateProduct_ShouldReturnErrorWhenCommandIsInvalid()
        {
            var command = new UpdateProductCommand(Guid.NewGuid(), "P", 2, 5);

            Assert.False(command.IsValid());
        }

        [Fact]
        public void UpdateProduct_ShouldBeSuccess()
        {
            var command = new UpdateProductCommand(Guid.NewGuid(), "Pipoca", 4, 5);

            Assert.True(command.IsValid());
        }
    }
}
