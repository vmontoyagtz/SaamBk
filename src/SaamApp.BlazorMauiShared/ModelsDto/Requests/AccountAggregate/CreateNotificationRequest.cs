using System;

namespace SaamApp.BlazorMauiShared.Models.Notification
{
    public class CreateNotificationRequest : BaseRequest
    {
        public Guid ApplicationUserId { get; set; }
        public string NotificationText { get; set; }
        public bool IsRead { get; set; }
        public DateTime NotificationTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
    }
}