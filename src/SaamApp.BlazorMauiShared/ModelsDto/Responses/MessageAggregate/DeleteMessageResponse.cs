using System;

namespace SaamApp.BlazorMauiShared.Models.Message
{
    public class DeleteMessageResponse : BaseResponse
    {
        public DeleteMessageResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteMessageResponse()
        {
        }
    }
}