using System;

namespace SaamApp.BlazorMauiShared.Models.ConversationStage
{
    public class GetByIdConversationStageRequest : BaseRequest
    {
        public Guid ConversationStageId { get; set; }
    }
}