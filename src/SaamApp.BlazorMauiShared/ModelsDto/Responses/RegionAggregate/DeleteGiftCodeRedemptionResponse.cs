using System;

namespace SaamApp.BlazorMauiShared.Models.GiftCodeRedemption
{
    public class DeleteGiftCodeRedemptionResponse : BaseResponse
    {
        public DeleteGiftCodeRedemptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteGiftCodeRedemptionResponse()
        {
        }
    }
}