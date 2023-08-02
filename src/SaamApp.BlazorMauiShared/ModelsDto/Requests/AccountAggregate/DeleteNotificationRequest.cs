using System;

namespace SaamApp.BlazorMauiShared.Models.Notification
{
    public class DeleteNotificationRequest : BaseRequest
    {
        public Guid NotificationId { get; set; }
    }
}