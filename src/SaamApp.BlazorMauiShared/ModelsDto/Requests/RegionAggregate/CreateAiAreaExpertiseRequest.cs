using System;

namespace SaamApp.BlazorMauiShared.Models.AiAreaExpertise
{
    public class CreateAiAreaExpertiseRequest : BaseRequest
    {
        public Guid RegionAreaAdvisorCategoryId { get; set; }
        public Guid ModelId { get; set; }
        public Guid TenantId { get; set; }
    }
}