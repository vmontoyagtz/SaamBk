using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.DiscountCodeRedemption
{
    public class CreateDiscountCodeRedemptionResponse : BaseResponse
    {
        public CreateDiscountCodeRedemptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateDiscountCodeRedemptionResponse()
        {
        }

        public DiscountCodeRedemptionDto DiscountCodeRedemption { get; set; } = new();
    }
}