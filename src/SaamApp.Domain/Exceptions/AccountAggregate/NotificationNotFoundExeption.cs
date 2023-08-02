using System;

namespace SaamApp.Domain.Exceptions
{
    public class NotificationNotFoundException : Exception
    {
        public NotificationNotFoundException(string message) : base(message)
        {
        }

        public NotificationNotFoundException(Guid notificationId) : base(
            $"No notification with id {notificationId} found.")
        {
        }
    }
}