using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Conversation
{
    public class GetByIdConversationResponse : BaseResponse
    {
        public GetByIdConversationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdConversationResponse()
        {
        }

        public ConversationDto Conversation { get; set; } = new();
    }
}