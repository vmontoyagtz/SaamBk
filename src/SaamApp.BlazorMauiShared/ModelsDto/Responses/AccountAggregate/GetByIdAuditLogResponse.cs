using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AuditLog
{
    public class GetByIdAuditLogResponse : BaseResponse
    {
        public GetByIdAuditLogResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAuditLogResponse()
        {
        }

        public AuditLogDto AuditLog { get; set; } = new();
    }
}