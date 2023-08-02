using System;

namespace SaamApp.BlazorMauiShared.Models.AiSession
{
    public class GetByIdAiSessionRequest : BaseRequest
    {
        public Guid AiSessionId { get; set; }
    }
}