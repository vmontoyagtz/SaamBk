using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PrepaidPackageRedemption
{
    public class GetByIdPrepaidPackageRedemptionResponse : BaseResponse
    {
        public GetByIdPrepaidPackageRedemptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdPrepaidPackageRedemptionResponse()
        {
        }

        public PrepaidPackageRedemptionDto PrepaidPackageRedemption { get; set; } = new();
    }
}