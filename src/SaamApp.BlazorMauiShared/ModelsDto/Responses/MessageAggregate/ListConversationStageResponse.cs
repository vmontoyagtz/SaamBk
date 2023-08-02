using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ConversationStage
{
    public class ListConversationStageResponse : BaseResponse
    {
        public ListConversationStageResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListConversationStageResponse()
        {
        }

        public List<ConversationStageDto> ConversationStages { get; set; } = new();

        public int Count { get; set; }
    }
}