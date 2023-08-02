using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Notification
{
    public class UpdateNotificationRequest : BaseRequest
    {
        public Guid NotificationId { get; set; }
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

        public static UpdateNotificationRequest FromDto(NotificationDto notificationDto)
        {
            return new UpdateNotificationRequest
            {
                NotificationId = notificationDto.NotificationId,
                ApplicationUserId = notificationDto.ApplicationUserId,
                NotificationText = notificationDto.NotificationText,
                IsRead = notificationDto.IsRead,
                NotificationTime = notificationDto.NotificationTime,
                CreatedAt = notificationDto.CreatedAt,
                CreatedBy = notificationDto.CreatedBy,
                UpdatedAt = notificationDto.UpdatedAt,
                UpdatedBy = notificationDto.UpdatedBy,
                IsDeleted = notificationDto.IsDeleted,
                TenantId = notificationDto.TenantId
            };
        }
    }
}