using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Message
{
    public class CreateMessageResponse : BaseResponse
    {
        public CreateMessageResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateMessageResponse()
        {
        }

        public MessageDto Message { get; set; } = new();
    }
}