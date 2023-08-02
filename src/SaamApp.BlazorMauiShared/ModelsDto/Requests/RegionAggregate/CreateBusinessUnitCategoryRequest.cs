using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitCategory
{
    public class CreateBusinessUnitCategoryRequest : BaseRequest
    {
        public Guid BusinessUnitId { get; set; }
        public Guid RegionAreaAdvisorCategoryId { get; set; }
    }
}