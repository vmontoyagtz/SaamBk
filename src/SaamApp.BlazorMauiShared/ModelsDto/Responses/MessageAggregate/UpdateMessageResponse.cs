using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Message
{
    public class UpdateMessageResponse : BaseResponse
    {
        public UpdateMessageResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateMessageResponse()
        {
        }

        public MessageDto Message { get; set; } = new();
    }
}