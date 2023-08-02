using System;

namespace SaamApp.BlazorMauiShared.Models.AiInteraction
{
    public class DeleteAiInteractionRequest : BaseRequest
    {
        public Guid AiInteractionId { get; set; }
    }
}