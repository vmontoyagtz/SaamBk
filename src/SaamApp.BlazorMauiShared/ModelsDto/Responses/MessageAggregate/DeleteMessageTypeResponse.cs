using System;

namespace SaamApp.BlazorMauiShared.Models.MessageType
{
    public class DeleteMessageTypeResponse : BaseResponse
    {
        public DeleteMessageTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteMessageTypeResponse()
        {
        }
    }
}