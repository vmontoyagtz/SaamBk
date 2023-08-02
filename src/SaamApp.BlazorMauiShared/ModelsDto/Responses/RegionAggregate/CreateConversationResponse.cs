using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Conversation
{
    public class CreateConversationResponse : BaseResponse
    {
        public CreateConversationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateConversationResponse()
        {
        }

        public ConversationDto Conversation { get; set; } = new();
    }
}