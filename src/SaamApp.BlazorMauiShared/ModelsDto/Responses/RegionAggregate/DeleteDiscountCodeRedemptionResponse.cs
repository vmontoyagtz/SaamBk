using System;

namespace SaamApp.BlazorMauiShared.Models.DiscountCodeRedemption
{
    public class DeleteDiscountCodeRedemptionResponse : BaseResponse
    {
        public DeleteDiscountCodeRedemptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteDiscountCodeRedemptionResponse()
        {
        }
    }
}