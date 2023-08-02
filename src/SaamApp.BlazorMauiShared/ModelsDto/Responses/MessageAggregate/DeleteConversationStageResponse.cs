using System;

namespace SaamApp.BlazorMauiShared.Models.ConversationStage
{
    public class DeleteConversationStageResponse : BaseResponse
    {
        public DeleteConversationStageResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteConversationStageResponse()
        {
        }
    }
}