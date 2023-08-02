using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.UnansweredConversation
{
    public class UpdateUnansweredConversationResponse : BaseResponse
    {
        public UpdateUnansweredConversationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateUnansweredConversationResponse()
        {
        }

        public UnansweredConversationDto UnansweredConversation { get; set; } = new();
    }
}