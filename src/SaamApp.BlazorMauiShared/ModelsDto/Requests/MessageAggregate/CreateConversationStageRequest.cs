using System;

namespace SaamApp.BlazorMauiShared.Models.ConversationStage
{
    public class CreateConversationStageRequest : BaseRequest
    {
        public string? ConversationStageName { get; set; }
        public string ConversationDescription { get; set; }
        public Guid TenantId { get; set; }
    }
}