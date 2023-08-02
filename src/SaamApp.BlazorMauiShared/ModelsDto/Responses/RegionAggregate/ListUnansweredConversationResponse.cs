using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.UnansweredConversation
{
    public class ListUnansweredConversationResponse : BaseResponse
    {
        public ListUnansweredConversationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListUnansweredConversationResponse()
        {
        }

        public List<UnansweredConversationDto> UnansweredConversations { get; set; } = new();

        public int Count { get; set; }
    }
}