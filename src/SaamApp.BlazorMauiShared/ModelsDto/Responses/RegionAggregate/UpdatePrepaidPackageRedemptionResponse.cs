using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PrepaidPackageRedemption
{
    public class UpdatePrepaidPackageRedemptionResponse : BaseResponse
    {
        public UpdatePrepaidPackageRedemptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdatePrepaidPackageRedemptionResponse()
        {
        }

        public PrepaidPackageRedemptionDto PrepaidPackageRedemption { get; set; } = new();
    }
}