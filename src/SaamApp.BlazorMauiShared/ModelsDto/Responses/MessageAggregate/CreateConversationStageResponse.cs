using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ConversationStage
{
    public class CreateConversationStageResponse : BaseResponse
    {
        public CreateConversationStageResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateConversationStageResponse()
        {
        }

        public ConversationStageDto ConversationStage { get; set; } = new();
    }
}