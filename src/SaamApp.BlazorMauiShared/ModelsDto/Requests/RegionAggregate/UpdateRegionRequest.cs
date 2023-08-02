using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Region
{
    public class UpdateRegionRequest : BaseRequest
    {
        public Guid RegionId { get; set; }
        public string RegionName { get; set; }
        public string RegionCode { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateRegionRequest FromDto(RegionDto regionDto)
        {
            return new UpdateRegionRequest
            {
                RegionId = regionDto.RegionId,
                RegionName = regionDto.RegionName,
                RegionCode = regionDto.RegionCode,
                TenantId = regionDto.TenantId
            };
        }
    }
}