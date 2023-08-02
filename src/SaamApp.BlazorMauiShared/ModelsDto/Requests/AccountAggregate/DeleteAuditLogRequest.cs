using System;

namespace SaamApp.BlazorMauiShared.Models.AuditLog
{
    public class DeleteAuditLogRequest : BaseRequest
    {
        public Guid AuditLogId { get; set; }
    }
}