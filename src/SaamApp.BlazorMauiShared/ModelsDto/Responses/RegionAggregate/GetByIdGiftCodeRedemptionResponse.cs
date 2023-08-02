using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.GiftCodeRedemption
{
    public class GetByIdGiftCodeRedemptionResponse : BaseResponse
    {
        public GetByIdGiftCodeRedemptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdGiftCodeRedemptionResponse()
        {
        }

        public GiftCodeRedemptionDto GiftCodeRedemption { get; set; } = new();
    }
}