using System;

namespace SaamApp.BlazorMauiShared.Models.RegionAreaAdvisorCategory
{
    public class GetByIdRegionAreaAdvisorCategoryRequest : BaseRequest
    {
        public Guid RegionAreaAdvisorCategoryId { get; set; }
    }
}