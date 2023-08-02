using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.MessageType
{
    public class UpdateMessageTypeRequest : BaseRequest
    {
        public Guid MessageTypeId { get; set; }
        public string MessageTypeName { get; set; }
        public string? MessageTypeDescription { get; set; }

        public static UpdateMessageTypeRequest FromDto(MessageTypeDto messageTypeDto)
        {
            return new UpdateMessageTypeRequest
            {
                MessageTypeId = messageTypeDto.MessageTypeId,
                MessageTypeName = messageTypeDto.MessageTypeName,
                MessageTypeDescription = messageTypeDto.MessageTypeDescription
            };
        }
    }
}