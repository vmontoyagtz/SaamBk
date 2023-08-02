using System;

namespace SaamApp.BlazorMauiShared.Models.AiSession
{
    public class CreateAiSessionRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int NumberOfInteractions { get; set; }
    }
}