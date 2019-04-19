using Loja.Domain.Core.Commands;
using Loja.Domain.Core.Notifications;
using Loja.Domain.Interfaces;
using MediatR;

namespace Loja.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediator _mediator;
        private readonly NotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow, IMediator mediator, INotificationHandler<Notification> notifications)
        {
            _uow = uow;
            _mediator = mediator;
            _notifications = (NotificationHandler)notifications;
        }

        public void NotifyErrors(Command command)
        {
            foreach (var error in command.ValidationResult.Errors)
            {
                _mediator.Publish(new Notification(command.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;

            _mediator.Publish(new Notification("Operação Inválida", "Foi encontrado um erro na operação!"));
            return false;
        }


    }
}
