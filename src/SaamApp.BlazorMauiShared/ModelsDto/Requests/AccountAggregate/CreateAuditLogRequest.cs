using System;

namespace SaamApp.BlazorMauiShared.Models.AuditLog
{
    public class CreateAuditLogRequest : BaseRequest
    {
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
    }
}