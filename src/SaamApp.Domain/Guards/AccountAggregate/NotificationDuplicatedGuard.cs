using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class NotificationGuardExtensions
    {
        public static void DuplicateNotification(this IGuardClause guardClause,
            IEnumerable<Notification> existingNotifications, Notification newNotification, string parameterName)
        {
            if (existingNotifications.Any(a => a.NotificationId == newNotification.NotificationId))
            {
                throw new DuplicateNotificationException("Cannot add duplicate notification.", parameterName);
            }
        }
    }
}