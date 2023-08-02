using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class NotificationGetListSpec : Specification<Notification>
    {
        public NotificationGetListSpec()
        {
            Query.Where(notification => notification.IsRead == true)
                .AsNoTracking();
        }
    }
}