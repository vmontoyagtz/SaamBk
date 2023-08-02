using System;

namespace SaamApp.BlazorMauiShared.Models.AiErrorLog
{
    public class GetByIdAiErrorLogRequest : BaseRequest
    {
        public Guid AiErrorLogId { get; set; }
    }
}