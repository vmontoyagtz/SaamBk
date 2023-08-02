using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.DiscountCodeRedemption
{
    public class UpdateDiscountCodeRedemptionResponse : BaseResponse
    {
        public UpdateDiscountCodeRedemptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateDiscountCodeRedemptionResponse()
        {
        }

        public DiscountCodeRedemptionDto DiscountCodeRedemption { get; set; } = new();
    }
}