using Loja.Domain.Commands.Product;
using Loja.Domain.Core.Notifications;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Loja.Domain.CommandHandlers
{
    public class ProductCommandHandler : CommandHandler, 
        IRequestHandler<RegisterProductCommand, bool>,
        IRequestHandler<UpdateProductCommand, bool>,
        IRequestHandler<RemoveProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public ProductCommandHandler(IUnitOfWork uow, 
            IProductRepository productRepository,
            IMediator mediator,
            INotificationHandler<Notification> notifications) : base(uow, mediator, notifications)
        {
            _productRepository = productRepository;
        }

        public Task<bool> Handle(RegisterProductCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyErrors(command);
                return Task.FromResult(false);
            }

            var product = new Product(command.Id, command.Name, command.Price);

            _productRepository.Add(product);

            if (!Commit())
                return Task.FromResult(false);

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyErrors(command);
                return Task.FromResult(false);
            }

            var product = new Product(command.Id, command.Name, command.Price);

            _productRepository.Update(product);

            if (!Commit())
                return Task.FromResult(false);

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveProductCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyErrors(command);
                return Task.FromResult(false);
            }

            _productRepository.Remove(command.Id);

            if (!Commit())
                return Task.FromResult(false);

            return Task.FromResult(true);
        }
    }
}
