using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.GiftCodeRedemption
{
    public class CreateGiftCodeRedemptionResponse : BaseResponse
    {
        public CreateGiftCodeRedemptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateGiftCodeRedemptionResponse()
        {
        }

        public GiftCodeRedemptionDto GiftCodeRedemption { get; set; } = new();
    }
}