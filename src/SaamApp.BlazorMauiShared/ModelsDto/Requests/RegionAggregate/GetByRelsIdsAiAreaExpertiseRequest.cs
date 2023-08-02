using System;

namespace SaamApp.BlazorMauiShared.Models.AiAreaExpertise
{
    public class GetByRelsIdsAiAreaExpertiseRequest : BaseRequest
    {
        public Guid ModelId { get; set; }
        public Guid RegionAreaAdvisorCategoryId { get; set; }
        public Guid TenantId { get; set; }
    }
}