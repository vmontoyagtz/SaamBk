using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiMemory
{
    public class ListAiMemoryResponse : BaseResponse
    {
        public ListAiMemoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAiMemoryResponse()
        {
        }

        public List<AiMemoryDto> AiMemories { get; set; } = new();

        public int Count { get; set; }
    }
}