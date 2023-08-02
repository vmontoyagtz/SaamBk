using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class NotificationDto
    {
        public NotificationDto() { } // AutoMapper required

        public NotificationDto(Guid notificationId, Guid applicationUserId, string notificationText, bool isRead,
            DateTime notificationTime, DateTime createdAt, Guid createdBy, DateTime? updatedAt, Guid? updatedBy,
            bool? isDeleted, Guid tenantId)
        {
            NotificationId = Guard.Against.NullOrEmpty(notificationId, nameof(notificationId));
            ApplicationUserId = Guard.Against.NullOrEmpty(applicationUserId, nameof(applicationUserId));
            NotificationText = Guard.Against.NullOrWhiteSpace(notificationText, nameof(notificationText));
            IsRead = Guard.Against.Null(isRead, nameof(isRead));
            NotificationTime = Guard.Against.OutOfSQLDateRange(notificationTime, nameof(notificationTime));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid NotificationId { get; set; }

        [Required(ErrorMessage = "Application User Id is required")]
        public Guid ApplicationUserId { get; set; }

        [Required(ErrorMessage = "Notification Text is required")]
        [MaxLength(100)]
        public string NotificationText { get; set; }

        [Required(ErrorMessage = "Is Read is required")]
        public bool IsRead { get; set; }

        [Required(ErrorMessage = "Notification Time is required")]
        public DateTime NotificationTime { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }
    }
}