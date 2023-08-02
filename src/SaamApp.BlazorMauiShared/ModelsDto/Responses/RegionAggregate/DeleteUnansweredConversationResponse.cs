using System;

namespace SaamApp.BlazorMauiShared.Models.UnansweredConversation
{
    public class DeleteUnansweredConversationResponse : BaseResponse
    {
        public DeleteUnansweredConversationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteUnansweredConversationResponse()
        {
        }
    }
}