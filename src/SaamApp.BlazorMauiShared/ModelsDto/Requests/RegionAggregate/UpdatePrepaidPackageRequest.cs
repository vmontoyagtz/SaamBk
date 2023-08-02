using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PrepaidPackage
{
    public class UpdatePrepaidPackageRequest : BaseRequest
    {
        public Guid PrepaidPackageId { get; set; }
        public Guid RegionId { get; set; }
        public string PrepaidPackageName { get; set; }
        public decimal PrepaidPackagePrice { get; set; }
        public bool? PrepaidPackageIsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }

        public static UpdatePrepaidPackageRequest FromDto(PrepaidPackageDto prepaidPackageDto)
        {
            return new UpdatePrepaidPackageRequest
            {
                PrepaidPackageId = prepaidPackageDto.PrepaidPackageId,
                RegionId = prepaidPackageDto.RegionId,
                PrepaidPackageName = prepaidPackageDto.PrepaidPackageName,
                PrepaidPackagePrice = prepaidPackageDto.PrepaidPackagePrice,
                PrepaidPackageIsActive = prepaidPackageDto.PrepaidPackageIsActive,
                CreatedAt = prepaidPackageDto.CreatedAt,
                CreatedBy = prepaidPackageDto.CreatedBy,
                UpdatedAt = prepaidPackageDto.UpdatedAt,
                UpdatedBy = prepaidPackageDto.UpdatedBy,
                IsDeleted = prepaidPackageDto.IsDeleted,
                TenantId = prepaidPackageDto.TenantId
            };
        }
    }
}