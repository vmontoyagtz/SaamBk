using System;

namespace SaamApp.BlazorMauiShared.Models.AiInteraction
{
    public class CreateAiInteractionRequest : BaseRequest
    {
        public Guid AiRobotId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid SessionId { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public DateTime InteractionTime { get; set; }
        public bool IsSuccessful { get; set; }
    }
}