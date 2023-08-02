using System;

namespace SaamApp.BlazorMauiShared.Models.AuditLog
{
    public class DeleteAuditLogResponse : BaseResponse
    {
        public DeleteAuditLogResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAuditLogResponse()
        {
        }
    }
}