using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AuditLogDto
    {
        public AuditLogDto() { } // AutoMapper required

        public AuditLogDto(Guid auditLogId, DateTime eventDateUTC, Guid applicationUserId, string? userName,
            string? userRoles, Guid tenantId, string eventType, string? tableName, string recordId,
            string? operationType, string? oldValues, string? newValues, string? changesMade, string? changeReason,
            string? operationResult, string? affectedFields, string? ipAddress, string? userAgent,
            string? additionalInfo)
        {
            AuditLogId = Guard.Against.NullOrEmpty(auditLogId, nameof(auditLogId));
            EventDateUTC = Guard.Against.OutOfSQLDateRange(eventDateUTC, nameof(eventDateUTC));
            ApplicationUserId = Guard.Against.NullOrEmpty(applicationUserId, nameof(applicationUserId));
            UserName = userName;
            UserRoles = userRoles;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
            EventType = Guard.Against.NullOrWhiteSpace(eventType, nameof(eventType));
            TableName = tableName;
            RecordId = Guard.Against.NullOrWhiteSpace(recordId, nameof(recordId));
            OperationType = operationType;
            OldValues = oldValues;
            NewValues = newValues;
            ChangesMade = changesMade;
            ChangeReason = changeReason;
            OperationResult = operationResult;
            AffectedFields = affectedFields;
            IpAddress = ipAddress;
            UserAgent = userAgent;
            AdditionalInfo = additionalInfo;
        }

        public Guid AuditLogId { get; set; }

        [Required(ErrorMessage = "Event Date UTC is required")]
        public DateTime EventDateUTC { get; set; }

        [Required(ErrorMessage = "Application User Id is required")]
        public Guid ApplicationUserId { get; set; }

        [MaxLength(100)] public string? UserName { get; set; }

        [MaxLength(100)] public string? UserRoles { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        [Required(ErrorMessage = "Event Type is required")]
        [MaxLength(100)]
        public string EventType { get; set; }

        [MaxLength(100)] public string? TableName { get; set; }

        [Required(ErrorMessage = "Record Id is required")]
        [MaxLength(100)]
        public string RecordId { get; set; }

        [MaxLength(100)] public string? OperationType { get; set; }

        [MaxLength(100)] public string? OldValues { get; set; }

        [MaxLength(100)] public string? NewValues { get; set; }

        [MaxLength(100)] public string? ChangesMade { get; set; }

        [MaxLength(100)] public string? ChangeReason { get; set; }

        [MaxLength(100)] public string? OperationResult { get; set; }

        [MaxLength(100)] public string? AffectedFields { get; set; }

        [MaxLength(100)] public string? IpAddress { get; set; }

        [MaxLength(100)] public string? UserAgent { get; set; }

        [MaxLength(100)] public string? AdditionalInfo { get; set; }
    }
}