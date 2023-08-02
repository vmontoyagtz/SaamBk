using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiInteraction
{
    public class CreateAiInteractionResponse : BaseResponse
    {
        public CreateAiInteractionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAiInteractionResponse()
        {
        }

        public AiInteractionDto AiInteraction { get; set; } = new();
    }
}