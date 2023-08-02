using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.MessageType
{
    public class ListMessageTypeResponse : BaseResponse
    {
        public ListMessageTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListMessageTypeResponse()
        {
        }

        public List<MessageTypeDto> MessageTypes { get; set; } = new();

        public int Count { get; set; }
    }
}