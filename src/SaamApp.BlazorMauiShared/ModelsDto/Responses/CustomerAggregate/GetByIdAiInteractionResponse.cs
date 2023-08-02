using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiInteraction
{
    public class GetByIdAiInteractionResponse : BaseResponse
    {
        public GetByIdAiInteractionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAiInteractionResponse()
        {
        }

        public AiInteractionDto AiInteraction { get; set; } = new();
    }
}