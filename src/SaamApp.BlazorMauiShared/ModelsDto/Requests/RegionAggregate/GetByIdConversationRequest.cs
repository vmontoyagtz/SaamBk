using System;

namespace SaamApp.BlazorMauiShared.Models.Conversation
{
    public class GetByIdConversationRequest : BaseRequest
    {
        public Guid ConversationId { get; set; }
    }
}