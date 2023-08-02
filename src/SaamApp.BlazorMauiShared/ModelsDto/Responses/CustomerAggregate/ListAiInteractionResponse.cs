using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiInteraction
{
    public class ListAiInteractionResponse : BaseResponse
    {
        public ListAiInteractionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAiInteractionResponse()
        {
        }

        public List<AiInteractionDto> AiInteractions { get; set; } = new();

        public int Count { get; set; }
    }
}