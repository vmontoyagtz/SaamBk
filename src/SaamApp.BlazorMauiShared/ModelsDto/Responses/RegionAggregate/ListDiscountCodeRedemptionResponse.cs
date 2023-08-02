using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.DiscountCodeRedemption
{
    public class ListDiscountCodeRedemptionResponse : BaseResponse
    {
        public ListDiscountCodeRedemptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListDiscountCodeRedemptionResponse()
        {
        }

        public List<DiscountCodeRedemptionDto> DiscountCodeRedemptions { get; set; } = new();

        public int Count { get; set; }
    }
}