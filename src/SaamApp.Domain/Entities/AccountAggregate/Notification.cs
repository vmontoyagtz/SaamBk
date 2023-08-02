using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class Notification : BaseEntityEv<Guid>, IAggregateRoot
    {
        private Notification() { } // EF required

        //[SetsRequiredMembers]
        public Notification(Guid notificationId, Guid applicationUserId, string notificationText, bool isRead,
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

        [Key] public Guid NotificationId { get; private set; }

        public Guid ApplicationUserId { get; private set; }

        public string NotificationText { get; private set; }

        public bool IsRead { get; private set; }

        public DateTime NotificationTime { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }

        public void SetNotificationText(string notificationText)
        {
            NotificationText = Guard.Against.NullOrEmpty(notificationText, nameof(notificationText));
        }
    }
}