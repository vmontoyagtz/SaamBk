using System;

namespace SaamApp.BlazorMauiShared.Models.ConversationStage
{
    public class DeleteConversationStageRequest : BaseRequest
    {
        public Guid ConversationStageId { get; set; }
    }
}