using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.RegionAreaAdvisorCategory
{
    public class UpdateRegionAreaAdvisorCategoryRequest : BaseRequest
    {
        public Guid RegionAreaAdvisorCategoryId { get; set; }
        public Guid AdvisorId { get; set; }
        public Guid AreaId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid RegionId { get; set; }

        public static UpdateRegionAreaAdvisorCategoryRequest FromDto(
            RegionAreaAdvisorCategoryDto regionAreaAdvisorCategoryDto)
        {
            return new UpdateRegionAreaAdvisorCategoryRequest
            {
                RegionAreaAdvisorCategoryId = regionAreaAdvisorCategoryDto.RegionAreaAdvisorCategoryId,
                AdvisorId = regionAreaAdvisorCategoryDto.AdvisorId,
                AreaId = regionAreaAdvisorCategoryDto.AreaId,
                CategoryId = regionAreaAdvisorCategoryDto.CategoryId,
                RegionId = regionAreaAdvisorCategoryDto.RegionId
            };
        }
    }
}