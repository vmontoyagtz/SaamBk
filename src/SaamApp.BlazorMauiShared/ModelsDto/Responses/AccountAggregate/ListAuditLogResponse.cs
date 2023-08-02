using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AuditLog
{
    public class ListAuditLogResponse : BaseResponse
    {
        public ListAuditLogResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAuditLogResponse()
        {
        }

        public List<AuditLogDto> AuditLogs { get; set; } = new();

        public int Count { get; set; }
    }
}