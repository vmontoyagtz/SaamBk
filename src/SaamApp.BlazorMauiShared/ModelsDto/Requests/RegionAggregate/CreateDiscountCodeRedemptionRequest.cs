using System;

namespace SaamApp.BlazorMauiShared.Models.DiscountCodeRedemption
{
    public class CreateDiscountCodeRedemptionRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
        public Guid DiscountCodeId { get; set; }
        public DateTime DiscountCodeRedemptionDate { get; set; }
    }
}