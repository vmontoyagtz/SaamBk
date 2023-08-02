using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Conversation
{
    public class ListConversationResponse : BaseResponse
    {
        public ListConversationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListConversationResponse()
        {
        }

        public List<ConversationDto> Conversations { get; set; } = new();

        public int Count { get; set; }
    }
}