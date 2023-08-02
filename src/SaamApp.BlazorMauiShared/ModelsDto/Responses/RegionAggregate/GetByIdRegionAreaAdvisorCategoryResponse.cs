using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.RegionAreaAdvisorCategory
{
    public class GetByIdRegionAreaAdvisorCategoryResponse : BaseResponse
    {
        public GetByIdRegionAreaAdvisorCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdRegionAreaAdvisorCategoryResponse()
        {
        }

        public RegionAreaAdvisorCategoryDto RegionAreaAdvisorCategory { get; set; } = new();
    }
}