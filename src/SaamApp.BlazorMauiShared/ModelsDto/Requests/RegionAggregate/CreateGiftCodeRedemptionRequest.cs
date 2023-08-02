using System;

namespace SaamApp.BlazorMauiShared.Models.GiftCodeRedemption
{
    public class CreateGiftCodeRedemptionRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
        public Guid GiftCodeId { get; set; }
        public DateTime GiftCodeRedemptionDate { get; set; }
    }
}