using System;

namespace SaamApp.BlazorMauiShared.Models.Notification
{
    public class GetByIdNotificationRequest : BaseRequest
    {
        public Guid NotificationId { get; set; }
    }
}