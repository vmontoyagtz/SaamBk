using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitCategory
{
    public class GetByRelsIdsBusinessUnitCategoryRequest : BaseRequest
    {
        public Guid RegionAreaAdvisorCategoryId { get; set; }
        public Guid BusinessUnitId { get; set; }
    }
}