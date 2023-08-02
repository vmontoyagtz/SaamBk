using System;

namespace SaamApp.BlazorMauiShared.Models.Conversation
{
    public class DeleteConversationRequest : BaseRequest
    {
        public Guid ConversationId { get; set; }
    }
}