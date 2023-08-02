using System;

namespace SaamApp.BlazorMauiShared.Models.Conversation
{
    public class DeleteConversationResponse : BaseResponse
    {
        public DeleteConversationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteConversationResponse()
        {
        }
    }
}