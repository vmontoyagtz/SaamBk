using System;

namespace SaamApp.BlazorMauiShared.Models.UnansweredConversation
{
    public class DeleteUnansweredConversationRequest : BaseRequest
    {
        public Guid UnansweredConversationId { get; set; }
    }
}