using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AuditLog
{
    public class UpdateAuditLogRequest : BaseRequest
    {
        public Guid AuditLogId { get; set; }
        public DateTime EventDateUTC { get; set; }
        public Guid ApplicationUserId { get; set; }
        public string? UserName { get; set; }
        public string? UserRoles { get; set; }
        public Guid TenantId { get; set; }
        public string EventType { get; set; }
        public string? TableName { get; set; }
        public string RecordId { get; set; }
        public string? OperationType { get; set; }
        public string? OldValues { get; set; }
        public string? NewValues { get; set; }
        public string? ChangesMade { get; set; }
        public string? ChangeReason { get; set; }
        public string? OperationResult { get; set; }
        public string? AffectedFields { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public string? AdditionalInfo { get; set; }

        public static UpdateAuditLogRequest FromDto(AuditLogDto auditLogDto)
        {
            return new UpdateAuditLogRequest
            {
                AuditLogId = auditLogDto.AuditLogId,
                EventDateUTC = auditLogDto.EventDateUTC,
                ApplicationUserId = auditLogDto.ApplicationUserId,
                UserName = auditLogDto.UserName,
                UserRoles = auditLogDto.UserRoles,
                TenantId = auditLogDto.TenantId,
                EventType = auditLogDto.EventType,
                TableName = auditLogDto.TableName,
                RecordId = auditLogDto.RecordId,
                OperationType = auditLogDto.OperationType,
                OldValues = auditLogDto.OldValues,
                NewValues = auditLogDto.NewValues,
                ChangesMade = auditLogDto.ChangesMade,
                ChangeReason = auditLogDto.ChangeReason,
                OperationResult = auditLogDto.OperationResult,
                AffectedFields = auditLogDto.AffectedFields,
                IpAddress = auditLogDto.IpAddress,
                UserAgent = auditLogDto.UserAgent,
                AdditionalInfo = auditLogDto.AdditionalInfo
            };
        }
    }
}