using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ConversationStage
{
    public class UpdateConversationStageRequest : BaseRequest
    {
        public Guid ConversationStageId { get; set; }
        public string? ConversationStageName { get; set; }
        public string ConversationDescription { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateConversationStageRequest FromDto(ConversationStageDto conversationStageDto)
        {
            return new UpdateConversationStageRequest
            {
                ConversationStageId = conversationStageDto.ConversationStageId,
                ConversationStageName = conversationStageDto.ConversationStageName,
                ConversationDescription = conversationStageDto.ConversationDescription,
                TenantId = conversationStageDto.TenantId
            };
        }
    }
}