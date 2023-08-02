using System;

namespace SaamApp.BlazorMauiShared.Models.RegionAreaAdvisorCategory
{
    public class CreateRegionAreaAdvisorCategoryRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
        public Guid AreaId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid RegionId { get; set; }
    }
}