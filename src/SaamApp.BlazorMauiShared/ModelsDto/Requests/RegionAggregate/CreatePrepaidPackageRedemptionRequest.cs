using System;

namespace SaamApp.BlazorMauiShared.Models.PrepaidPackageRedemption
{
    public class CreatePrepaidPackageRedemptionRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
        public Guid PrepaidPackageId { get; set; }
        public decimal PrepaidPackageAmount { get; set; }
        public DateTime PrepaidPackageRedemptionDate { get; set; }
    }
}