using System;

namespace SaamApp.BlazorMauiShared.Models.AiFeedback
{
    public class CreateAiFeedbackRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
        public Guid ModelId { get; set; }
        public string? Question { get; set; }
        public string? Response { get; set; }
        public bool? UserFeedback { get; set; }
        public Guid AISessionId { get; set; }
        public DateTime InteractionTime { get; set; }
    }
}