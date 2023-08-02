using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PrepaidPackageRedemption
{
    public class CreatePrepaidPackageRedemptionResponse : BaseResponse
    {
        public CreatePrepaidPackageRedemptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreatePrepaidPackageRedemptionResponse()
        {
        }

        public PrepaidPackageRedemptionDto PrepaidPackageRedemption { get; set; } = new();
    }
}