using System;

namespace SaamApp.BlazorMauiShared.Models.PrepaidPackageRedemption
{
    public class GetByIdPrepaidPackageRedemptionRequest : BaseRequest
    {
        public Guid PrepaidPackageRedemptionId { get; set; }
    }
}