using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.RegionAreaAdvisorCategory
{
    public class ListRegionAreaAdvisorCategoryResponse : BaseResponse
    {
        public ListRegionAreaAdvisorCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListRegionAreaAdvisorCategoryResponse()
        {
        }

        public List<RegionAreaAdvisorCategoryDto> RegionAreaAdvisorCategories { get; set; } = new();

        public int Count { get; set; }
    }
}