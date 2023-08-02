using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.UnansweredConversation
{
    public class CreateUnansweredConversationResponse : BaseResponse
    {
        public CreateUnansweredConversationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateUnansweredConversationResponse()
        {
        }

        public UnansweredConversationDto UnansweredConversation { get; set; } = new();
    }
}