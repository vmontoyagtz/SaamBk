using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.MessageType
{
    public class UpdateMessageTypeResponse : BaseResponse
    {
        public UpdateMessageTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateMessageTypeResponse()
        {
        }

        public MessageTypeDto MessageType { get; set; } = new();
    }
}