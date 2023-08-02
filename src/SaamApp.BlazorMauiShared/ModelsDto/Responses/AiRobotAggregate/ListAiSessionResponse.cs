using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiSession
{
    public class ListAiSessionResponse : BaseResponse
    {
        public ListAiSessionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAiSessionResponse()
        {
        }

        public List<AiSessionDto> AiSessions { get; set; } = new();

        public int Count { get; set; }
    }
}