using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AuditLog
{
    public class CreateAuditLogResponse : BaseResponse
    {
        public CreateAuditLogResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAuditLogResponse()
        {
        }

        public AuditLogDto AuditLog { get; set; } = new();
    }
}