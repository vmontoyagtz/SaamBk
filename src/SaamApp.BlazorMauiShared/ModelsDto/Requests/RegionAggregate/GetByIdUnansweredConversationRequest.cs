using System;

namespace SaamApp.BlazorMauiShared.Models.UnansweredConversation
{
    public class GetByIdUnansweredConversationRequest : BaseRequest
    {
        public Guid UnansweredConversationId { get; set; }
    }
}