using Loja.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Loja.WebAPI.Controllers
{
    public class ApiController : ControllerBase
    {
        private readonly NotificationHandler _notifications;

        protected ApiController(INotificationHandler<Notification> notifications)
        {
            _notifications = (NotificationHandler)notifications;
        }

        protected bool IsValid()
        {
            return (!_notifications.HasNotifications());
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValid())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                data = _notifications.GetNotifications().Select(p => p.Value)
            });
        }

        protected IActionResult ResponseError()
        {
            var errors = ModelState.Values.SelectMany(p => p.Errors);

            return BadRequest(new
            {
                success = false,
                errors = errors.Select(p => p.ErrorMessage)
            });
        }
    }
}
