using System;

namespace SaamApp.BlazorMauiShared.Models.PrepaidPackageRedemption
{
    public class DeletePrepaidPackageRedemptionResponse : BaseResponse
    {
        public DeletePrepaidPackageRedemptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeletePrepaidPackageRedemptionResponse()
        {
        }
    }
}