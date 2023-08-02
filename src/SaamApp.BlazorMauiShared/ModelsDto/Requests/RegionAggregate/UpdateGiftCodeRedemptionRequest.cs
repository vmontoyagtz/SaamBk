using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.GiftCodeRedemption
{
    public class UpdateGiftCodeRedemptionRequest : BaseRequest
    {
        public Guid GiftCodeRedemptionId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid GiftCodeId { get; set; }
        public DateTime GiftCodeRedemptionDate { get; set; }

        public static UpdateGiftCodeRedemptionRequest FromDto(GiftCodeRedemptionDto giftCodeRedemptionDto)
        {
            return new UpdateGiftCodeRedemptionRequest
            {
                GiftCodeRedemptionId = giftCodeRedemptionDto.GiftCodeRedemptionId,
                CustomerId = giftCodeRedemptionDto.CustomerId,
                GiftCodeId = giftCodeRedemptionDto.GiftCodeId,
                GiftCodeRedemptionDate = giftCodeRedemptionDto.GiftCodeRedemptionDate
            };
        }
    }
}