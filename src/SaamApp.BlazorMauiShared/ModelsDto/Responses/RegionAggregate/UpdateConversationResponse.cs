using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Conversation
{
    public class UpdateConversationResponse : BaseResponse
    {
        public UpdateConversationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateConversationResponse()
        {
        }

        public ConversationDto Conversation { get; set; } = new();
    }
}