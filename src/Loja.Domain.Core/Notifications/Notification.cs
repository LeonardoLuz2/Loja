using Loja.Domain.Core.Events;
using System;

namespace Loja.Domain.Core.Notifications
{
    public class Notification : Event
    {
        public Guid NotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }

        public Notification(string key, string value)
        {
            NotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
        }
    }
}
