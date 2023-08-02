using System;

namespace SaamApp.BlazorMauiShared.Models.AiInteraction
{
    public class GetByIdAiInteractionRequest : BaseRequest
    {
        public Guid AiInteractionId { get; set; }
    }
}