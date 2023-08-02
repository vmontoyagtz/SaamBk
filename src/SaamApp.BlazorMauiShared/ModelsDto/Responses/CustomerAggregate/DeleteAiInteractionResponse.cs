using System;

namespace SaamApp.BlazorMauiShared.Models.AiInteraction
{
    public class DeleteAiInteractionResponse : BaseResponse
    {
        public DeleteAiInteractionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAiInteractionResponse()
        {
        }
    }
}