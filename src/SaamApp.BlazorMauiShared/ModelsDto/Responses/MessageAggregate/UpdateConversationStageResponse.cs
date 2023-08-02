using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ConversationStage
{
    public class UpdateConversationStageResponse : BaseResponse
    {
        public UpdateConversationStageResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateConversationStageResponse()
        {
        }

        public ConversationStageDto ConversationStage { get; set; } = new();
    }
}