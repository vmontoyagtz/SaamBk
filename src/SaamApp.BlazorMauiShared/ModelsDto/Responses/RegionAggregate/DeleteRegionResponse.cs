using System;

namespace SaamApp.BlazorMauiShared.Models.Region
{
    public class DeleteRegionResponse : BaseResponse
    {
        public DeleteRegionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteRegionResponse()
        {
        }
    }
}