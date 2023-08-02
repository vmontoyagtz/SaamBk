using System;

namespace SaamApp.BlazorMauiShared.Models.AiErrorLog
{
    public class DeleteAiErrorLogRequest : BaseRequest
    {
        public Guid AiErrorLogId { get; set; }
    }
}