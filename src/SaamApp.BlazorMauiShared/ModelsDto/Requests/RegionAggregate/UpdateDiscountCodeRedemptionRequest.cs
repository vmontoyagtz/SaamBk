using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.DiscountCodeRedemption
{
    public class UpdateDiscountCodeRedemptionRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DiscountCodeId { get; set; }
        public DateTime DiscountCodeRedemptionDate { get; set; }

        public static UpdateDiscountCodeRedemptionRequest FromDto(DiscountCodeRedemptionDto discountCodeRedemptionDto)
        {
            return new UpdateDiscountCodeRedemptionRequest
            {
                RowId = discountCodeRedemptionDto.RowId,
                CustomerId = discountCodeRedemptionDto.CustomerId,
                DiscountCodeId = discountCodeRedemptionDto.DiscountCodeId,
                DiscountCodeRedemptionDate = discountCodeRedemptionDto.DiscountCodeRedemptionDate
            };
        }
    }
}