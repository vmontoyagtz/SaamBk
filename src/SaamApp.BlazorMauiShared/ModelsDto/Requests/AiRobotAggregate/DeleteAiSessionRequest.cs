using System;

namespace SaamApp.BlazorMauiShared.Models.AiSession
{
    public class DeleteAiSessionRequest : BaseRequest
    {
        public Guid AiSessionId { get; set; }
    }
}