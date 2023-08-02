using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.UnansweredConversation
{
    public class GetByIdUnansweredConversationResponse : BaseResponse
    {
        public GetByIdUnansweredConversationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdUnansweredConversationResponse()
        {
        }

        public UnansweredConversationDto UnansweredConversation { get; set; } = new();
    }
}