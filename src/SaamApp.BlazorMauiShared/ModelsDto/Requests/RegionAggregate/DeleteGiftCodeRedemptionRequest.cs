using System;

namespace SaamApp.BlazorMauiShared.Models.GiftCodeRedemption
{
    public class DeleteGiftCodeRedemptionRequest : BaseRequest
    {
        public Guid GiftCodeRedemptionId { get; set; }
    }
}