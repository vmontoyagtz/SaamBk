using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.GiftCodeRedemption
{
    public class UpdateGiftCodeRedemptionResponse : BaseResponse
    {
        public UpdateGiftCodeRedemptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateGiftCodeRedemptionResponse()
        {
        }

        public GiftCodeRedemptionDto GiftCodeRedemption { get; set; } = new();
    }
}