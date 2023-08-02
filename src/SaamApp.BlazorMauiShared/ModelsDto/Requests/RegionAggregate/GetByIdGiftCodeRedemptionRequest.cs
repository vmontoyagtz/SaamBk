using System;

namespace SaamApp.BlazorMauiShared.Models.GiftCodeRedemption
{
    public class GetByIdGiftCodeRedemptionRequest : BaseRequest
    {
        public Guid GiftCodeRedemptionId { get; set; }
    }
}