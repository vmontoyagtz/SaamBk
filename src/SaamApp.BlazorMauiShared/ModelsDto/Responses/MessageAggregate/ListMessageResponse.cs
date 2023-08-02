using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Message
{
    public class ListMessageResponse : BaseResponse
    {
        public ListMessageResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListMessageResponse()
        {
        }

        public List<MessageDto> Messages { get; set; } = new();

        public int Count { get; set; }
    }
}