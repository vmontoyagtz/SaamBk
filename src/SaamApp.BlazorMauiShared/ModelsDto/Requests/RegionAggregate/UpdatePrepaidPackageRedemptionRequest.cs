using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PrepaidPackageRedemption
{
    public class UpdatePrepaidPackageRedemptionRequest : BaseRequest
    {
        public Guid PrepaidPackageRedemptionId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid PrepaidPackageId { get; set; }
        public decimal PrepaidPackageAmount { get; set; }
        public DateTime PrepaidPackageRedemptionDate { get; set; }

        public static UpdatePrepaidPackageRedemptionRequest FromDto(
            PrepaidPackageRedemptionDto prepaidPackageRedemptionDto)
        {
            return new UpdatePrepaidPackageRedemptionRequest
            {
                PrepaidPackageRedemptionId = prepaidPackageRedemptionDto.PrepaidPackageRedemptionId,
                CustomerId = prepaidPackageRedemptionDto.CustomerId,
                PrepaidPackageId = prepaidPackageRedemptionDto.PrepaidPackageId,
                PrepaidPackageAmount = prepaidPackageRedemptionDto.PrepaidPackageAmount,
                PrepaidPackageRedemptionDate = prepaidPackageRedemptionDto.PrepaidPackageRedemptionDate
            };
        }
    }
}