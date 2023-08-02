using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.RegionAreaAdvisorCategory
{
    public class CreateRegionAreaAdvisorCategoryResponse : BaseResponse
    {
        public CreateRegionAreaAdvisorCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateRegionAreaAdvisorCategoryResponse()
        {
        }

        public RegionAreaAdvisorCategoryDto RegionAreaAdvisorCategory { get; set; } = new();
    }
}