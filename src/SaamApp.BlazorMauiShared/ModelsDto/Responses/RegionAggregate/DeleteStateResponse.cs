using System;

namespace SaamApp.BlazorMauiShared.Models.State
{
    public class DeleteStateResponse : BaseResponse
    {
        public DeleteStateResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteStateResponse()
        {
        }
    }
}