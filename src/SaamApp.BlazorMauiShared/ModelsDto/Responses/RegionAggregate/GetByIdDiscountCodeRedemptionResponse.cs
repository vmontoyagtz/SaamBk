using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.DiscountCodeRedemption
{
    public class GetByIdDiscountCodeRedemptionResponse : BaseResponse
    {
        public GetByIdDiscountCodeRedemptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdDiscountCodeRedemptionResponse()
        {
        }

        public DiscountCodeRedemptionDto DiscountCodeRedemption { get; set; } = new();
    }
}