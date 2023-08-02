using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.MessageType
{
    public class GetByIdMessageTypeResponse : BaseResponse
    {
        public GetByIdMessageTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdMessageTypeResponse()
        {
        }

        public MessageTypeDto MessageType { get; set; } = new();
    }
}