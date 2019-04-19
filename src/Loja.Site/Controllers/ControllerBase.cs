using Loja.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Site.Controllers
{
    public class ControllerBase : Controller
    {
        private readonly NotificationHandler _notifications;

        public ControllerBase(INotificationHandler<Notification> notifications)
        {
            _notifications = (NotificationHandler)notifications;
        }

        public bool IsValid()
        {
            return (!_notifications.HasNotifications());
        }

        public void NotifyErrors()
        {
            _notifications.GetNotifications()
                .ForEach(p => ModelState.AddModelError(string.Empty, p.Value));
        }
    }
}
