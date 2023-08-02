using System;

namespace SaamApp.BlazorMauiShared.Models.PrepaidPackageRedemption
{
    public class DeletePrepaidPackageRedemptionRequest : BaseRequest
    {
        public Guid PrepaidPackageRedemptionId { get; set; }
    }
}