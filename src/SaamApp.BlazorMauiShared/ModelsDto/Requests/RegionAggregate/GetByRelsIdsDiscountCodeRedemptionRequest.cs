using System;

namespace SaamApp.BlazorMauiShared.Models.DiscountCodeRedemption
{
    public class GetByRelsIdsDiscountCodeRedemptionRequest : BaseRequest
    {
        public DateTime DiscountCodeRedemptionDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DiscountCodeId { get; set; }
    }
}