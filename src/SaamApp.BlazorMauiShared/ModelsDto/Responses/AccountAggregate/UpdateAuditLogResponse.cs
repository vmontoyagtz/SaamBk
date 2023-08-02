using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AuditLog
{
    public class UpdateAuditLogResponse : BaseResponse
    {
        public UpdateAuditLogResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAuditLogResponse()
        {
        }

        public AuditLogDto AuditLog { get; set; } = new();
    }
}