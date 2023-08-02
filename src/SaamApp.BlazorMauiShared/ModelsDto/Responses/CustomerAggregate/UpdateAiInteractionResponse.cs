using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiInteraction
{
    public class UpdateAiInteractionResponse : BaseResponse
    {
        public UpdateAiInteractionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAiInteractionResponse()
        {
        }

        public AiInteractionDto AiInteraction { get; set; } = new();
    }
}