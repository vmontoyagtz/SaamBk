using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.MessageType
{
    public class CreateMessageTypeResponse : BaseResponse
    {
        public CreateMessageTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateMessageTypeResponse()
        {
        }

        public MessageTypeDto MessageType { get; set; } = new();
    }
}