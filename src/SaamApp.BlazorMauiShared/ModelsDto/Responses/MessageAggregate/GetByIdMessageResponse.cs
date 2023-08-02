using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Message
{
    public class GetByIdMessageResponse : BaseResponse
    {
        public GetByIdMessageResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdMessageResponse()
        {
        }

        public MessageDto Message { get; set; } = new();
    }
}