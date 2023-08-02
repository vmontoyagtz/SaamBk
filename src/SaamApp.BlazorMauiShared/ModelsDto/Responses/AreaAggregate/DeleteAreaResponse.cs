using System;

namespace SaamApp.BlazorMauiShared.Models.Area
{
    public class DeleteAreaResponse : BaseResponse
    {
        public DeleteAreaResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAreaResponse()
        {
        }
    }
}