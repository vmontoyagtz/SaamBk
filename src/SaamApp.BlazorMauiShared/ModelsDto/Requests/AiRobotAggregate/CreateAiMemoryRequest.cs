using System;

namespace SaamApp.BlazorMauiShared.Models.AiMemory
{
    public class CreateAiMemoryRequest : BaseRequest
    {
        public Guid ModelId { get; set; }
        public string? Question { get; set; }
        public string? Response { get; set; }
        public DateTime InteractionTime { get; set; }
        public Guid TenantId { get; set; }
    }
}