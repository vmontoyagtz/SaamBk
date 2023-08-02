using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class NotificationByIdWithIncludesSpec : Specification<Notification>, ISingleResultSpecification
    {
        public NotificationByIdWithIncludesSpec(Guid notificationId)
        {
            Guard.Against.NullOrEmpty(notificationId, nameof(notificationId));
            Query.Where(notification => notification.NotificationId == notificationId)
                .AsNoTracking();
        }
    }
}