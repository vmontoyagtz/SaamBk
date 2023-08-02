using System;

namespace SaamApp.BlazorMauiShared.Models.AuditLog
{
    public class GetByIdAuditLogRequest : BaseRequest
    {
        public Guid AuditLogId { get; set; }
    }
}