using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiErrorLog
{
    public class ListAiErrorLogResponse : BaseResponse
    {
        public ListAiErrorLogResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAiErrorLogResponse()
        {
        }

        public List<AiErrorLogDto> AiErrorLogs { get; set; } = new();

        public int Count { get; set; }
    }
}