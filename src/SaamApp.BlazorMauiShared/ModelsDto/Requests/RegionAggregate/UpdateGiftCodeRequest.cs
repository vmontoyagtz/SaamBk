using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.GiftCode
{
    public class UpdateGiftCodeRequest : BaseRequest
    {
        public Guid GiftCodeId { get; set; }
        public Guid RegionId { get; set; }
        public string? GiftCodeName { get; set; }
        public string GiftCodeValue { get; set; }
        public decimal GiftCodeAmount { get; set; }
        public DateTime GiftCodeStartDate { get; set; }
        public DateTime? GiftCodeEndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateGiftCodeRequest FromDto(GiftCodeDto giftCodeDto)
        {
            return new UpdateGiftCodeRequest
            {
                GiftCodeId = giftCodeDto.GiftCodeId,
                RegionId = giftCodeDto.RegionId,
                GiftCodeName = giftCodeDto.GiftCodeName,
                GiftCodeValue = giftCodeDto.GiftCodeValue,
                GiftCodeAmount = giftCodeDto.GiftCodeAmount,
                GiftCodeStartDate = giftCodeDto.GiftCodeStartDate,
                GiftCodeEndDate = giftCodeDto.GiftCodeEndDate,
                CreatedAt = giftCodeDto.CreatedAt,
                CreatedBy = giftCodeDto.CreatedBy,
                UpdatedAt = giftCodeDto.UpdatedAt,
                UpdatedBy = giftCodeDto.UpdatedBy,
                IsDeleted = giftCodeDto.IsDeleted,
                TenantId = giftCodeDto.TenantId
            };
        }
    }
}