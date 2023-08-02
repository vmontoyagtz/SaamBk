using System;

namespace SaamApp.BlazorMauiShared.Models.RegionAreaAdvisorCategory
{
    public class DeleteRegionAreaAdvisorCategoryRequest : BaseRequest
    {
        public Guid RegionAreaAdvisorCategoryId { get; set; }
    }
}