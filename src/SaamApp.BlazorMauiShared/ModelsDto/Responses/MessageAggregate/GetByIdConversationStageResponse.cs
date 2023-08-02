using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ConversationStage
{
    public class GetByIdConversationStageResponse : BaseResponse
    {
        public GetByIdConversationStageResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdConversationStageResponse()
        {
        }

        public ConversationStageDto ConversationStage { get; set; } = new();
    }
}