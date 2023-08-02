using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.DiscountCode
{
    public class UpdateDiscountCodeRequest : BaseRequest
    {
        public Guid DiscountCodeId { get; set; }
        public Guid RegionId { get; set; }
        public string DiscountCodeName { get; set; }
        public string DiscountCodeValue { get; set; }
        public decimal DiscountCodePercentage { get; set; }
        public DateTime DiscountCodeStartDate { get; set; }
        public DateTime? DiscountCodeEndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateDiscountCodeRequest FromDto(DiscountCodeDto discountCodeDto)
        {
            return new UpdateDiscountCodeRequest
            {
                DiscountCodeId = discountCodeDto.DiscountCodeId,
                RegionId = discountCodeDto.RegionId,
                DiscountCodeName = discountCodeDto.DiscountCodeName,
                DiscountCodeValue = discountCodeDto.DiscountCodeValue,
                DiscountCodePercentage = discountCodeDto.DiscountCodePercentage,
                DiscountCodeStartDate = discountCodeDto.DiscountCodeStartDate,
                DiscountCodeEndDate = discountCodeDto.DiscountCodeEndDate,
                CreatedAt = discountCodeDto.CreatedAt,
                CreatedBy = discountCodeDto.CreatedBy,
                UpdatedAt = discountCodeDto.UpdatedAt,
                UpdatedBy = discountCodeDto.UpdatedBy,
                IsDeleted = discountCodeDto.IsDeleted,
                TenantId = discountCodeDto.TenantId
            };
        }
    }
}