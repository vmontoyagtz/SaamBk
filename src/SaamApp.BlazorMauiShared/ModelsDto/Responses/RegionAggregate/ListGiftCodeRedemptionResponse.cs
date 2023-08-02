using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.GiftCodeRedemption
{
    public class ListGiftCodeRedemptionResponse : BaseResponse
    {
        public ListGiftCodeRedemptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListGiftCodeRedemptionResponse()
        {
        }

        public List<GiftCodeRedemptionDto> GiftCodeRedemptions { get; set; } = new();

        public int Count { get; set; }
    }
}