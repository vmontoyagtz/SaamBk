using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.RegionAreaAdvisorCategory
{
    public class UpdateRegionAreaAdvisorCategoryResponse : BaseResponse
    {
        public UpdateRegionAreaAdvisorCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateRegionAreaAdvisorCategoryResponse()
        {
        }

        public RegionAreaAdvisorCategoryDto RegionAreaAdvisorCategory { get; set; } = new();
    }
}