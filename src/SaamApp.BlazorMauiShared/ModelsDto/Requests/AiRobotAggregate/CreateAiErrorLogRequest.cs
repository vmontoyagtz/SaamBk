using System;

namespace SaamApp.BlazorMauiShared.Models.AiErrorLog
{
    public class CreateAiErrorLogRequest : BaseRequest
    {
        public Guid ModelId { get; set; }
        public DateTime ErrorTime { get; set; }
        public string? ErrorMessage { get; set; }
        public Guid TenantId { get; set; }
    }
}